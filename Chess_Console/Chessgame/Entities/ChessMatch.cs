using System.Collections.Generic;
using Chessboard.Entities;
using Chessboard.Enums;
using Chessgame.Exceptions;

namespace Chessgame.Entities
{
    class ChessMatch
    {
        //Variables
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Check { get; private set; }
        public HashSet<Piece> PiecesOnTheBoard { get; private set; }
        public HashSet<Piece> CapturedPieces { get; private set; }

        //Constructors
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;

            PiecesOnTheBoard = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();

            PlaceInitialPieces();
        }

        //Methods
        private Piece MakeMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        private void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destination);
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destination);
                CapturedPieces.Remove(capturedPiece);
            }

            Board.PlacePiece(piece, origin);
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Red;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            //Exceptions
            if (Board.GetPiece(position) == null)
            {
                throw new GameException("There is no piece in the chosen origin position");
            }
            if (!Board.GetPiece(position).IsThereAnyPossibleMove())
            {
                throw new GameException("There are no movements possible for the piece of origin chosen!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            //Exceptions
            if (Board.GetPiece(origin).GetPossibleMove(destination))
            {
                throw new GameException("Invalid destination position!");
            }
        }

        private Color OpponentColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Red;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece king in PiecesOnTheBoard)
            {
                if (king is King)
                {
                    return king;
                }
            }

            return null;
        }

        private bool TestCheck(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new GameException($"There is no {color} king on the board!");
            }

            foreach (Piece opponentPieces in GetPiecesOnTheBoard(OpponentColor(color)))
            {
                bool[,] mat = opponentPieces.PossibleMoves();
                if (mat[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public void PerformsMove(Position origin, Position destination)
        {
            Piece capturedPiece = MakeMove(origin, destination);

            //Exceptions
            if (TestCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new GameException("You cannot put yourself in check!");
            }

            //Opponent in check
            if (TestCheck(OpponentColor(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            Turn++;
            ChangePlayer();
        }

        public HashSet<Piece> GetPiecesOnTheBoard(Color color)
        {
            HashSet<Piece> piecesOnTheBoard = new HashSet<Piece>();
            foreach (ChessPiece chessPiece in PiecesOnTheBoard)
            {
                if (chessPiece.Color == color)
                {
                    PiecesOnTheBoard.Add(chessPiece);
                }
            }

            piecesOnTheBoard.ExceptWith(GetCapturedPieces(color));
            return piecesOnTheBoard;
        }

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> capturedPieces = new HashSet<Piece>();
            foreach (ChessPiece chessPiece in CapturedPieces)
            {
                if (chessPiece.Color == color)
                {
                    capturedPieces.Add(chessPiece);
                }
            }

            return capturedPieces;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
            PiecesOnTheBoard.Add(piece);
        }

        private void PlaceInitialPieces()
        {
            //White Pieces
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
        }
    }
}
