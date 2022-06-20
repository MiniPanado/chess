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
        private void MakeMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
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

        public void PerformsMove(Position origin, Position destination)
        {
            MakeMove(origin, destination);
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
