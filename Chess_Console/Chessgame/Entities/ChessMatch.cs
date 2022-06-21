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
        public bool CheckMate { get; private set; }
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
        public ChessPiece PerformsChessMove(ChessPosition origin, ChessPosition destination)
        {
            Piece capturedPiece = MakeMove(origin, destination);

            //Exceptions
            if (TestCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new GameException("You cannot put yourself in check!");
            }

            Check = TestCheck(Opponent(CurrentPlayer)); //Opponent in Check
            CheckMate = TestCheckMate(Opponent(CurrentPlayer)); //Opponent in CheckMate

            Turn++;
            ChangePlayer();
        }

        private Piece MakeMove(Position source, Position target)
        {
            ChessPiece piece = (ChessPiece)Board.RemovePiece(source);
            piece.IncreaseMoveCount();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(piece, target);

            if (capturedPiece != null)
            {
                PiecesOnTheBoard.Remove(capturedPiece);
                CapturedPieces.Add(capturedPiece);
            }

            // #specialmove castling
            if (piece is King)
            {
                if (target.Column == source.Column + 2)
                {
                    // #specialmove castling kingside rook
                    Position sourceRook = new Position(source.Row, source.Column + 3);
                    Position targetRook = new Position(source.Row, source.Row + 1);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(sourceRook);

                    Board.PlacePiece(rook, targetRook);
                    rook.IncreaseMoveCount();
                }
                else if (target.Column == source.Column - 2)
                {
                    // #specialmove castling queenside rook
                    Position sourceRook = new Position(source.Row, source.Column - 4);
                    Position targetRook = new Position(source.Row, source.Row - 2);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(sourceRook);

                    Board.PlacePiece(rook, targetRook);
                    rook.IncreaseMoveCount();
                }
            }

            return capturedPiece;
        }

        private void UndoMove(Position source, Position target, Piece capturedPiece)
        {
            ChessPiece piece = (ChessPiece)Board.RemovePiece(target);
            piece.DecreaseMoveCount();
            Board.PlacePiece(piece, source);

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                CapturedPieces.Remove(capturedPiece);
            }

            if (piece is King)
            {
                if (target.Column == source.Column + 2)
                {
                    // #specialmove castling kingside rook
                    Position sourceRook = new Position(source.Row, source.Column + 3);
                    Position targetRook = new Position(source.Row, source.Row + 1);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(targetRook);

                    rook.DecreaseMoveCount();
                    Board.PlacePiece(rook, sourceRook);
                }
                else if (target.Column == source.Column - 2)
                {
                    // #specialmove castling queenside rook
                    Position sourceRook = new Position(source.Row, source.Column - 4);
                    Position targetRook = new Position(source.Row, source.Row - 2);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(targetRook);

                    rook.DecreaseMoveCount();
                    Board.PlacePiece(rook, sourceRook);

                }
            }

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

        private void ValidateSourcePosition(Position position)
        {
            //Exceptions
            ChessPiece piece = (ChessPiece)Board.GetPiece(position);

            if (!Board.ThereIsAPiece(position))
            {
                throw new GameException("There is no piece on source position");
            }
            if (CurrentPlayer != piece.Color)
            {
                throw new GameException("The chosen piece is not yours");
            }
            if (piece.IsThereAnyPossibleMove())
            {
                throw new GameException("There is no possible moves for the chosen piece");
            }
        }

        private void ValidateTargetPosition(Position origin, Position destination)
        {
            //Exceptions
            ChessPiece piece = (ChessPiece)Board.GetPiece(origin);

            if (piece.GetPossibleMove(destination))
            {
                throw new GameException("The chosen piece can't move to target position");
            }
        }

        private void nextTurn()
        {
            Turn++;
            CurrentPlayer = (CurrentPlayer == Color.White) ? Color.Red : Color.White;
        }

        private Color Opponent(Color color)
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

        private ChessPiece King(Color color)
        {
            foreach (ChessPiece piece in GetPiecesOnTheBoard(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            throw new GameException($"There is no {color} king on the board");
        }

        private bool TestCheck(Color color)
        {
            Position kingPos = King(color).Position;

            foreach (ChessPiece opponentPieces in GetPiecesOnTheBoard(Opponent(color)))
            {
                bool[,] mat = opponentPieces.PossibleMoves();
                if (mat[kingPos.Row, kingPos.Column])
                {
                    return true;
                }
            }

            return false;
        }

        private bool TestCheckMate(Color color)
        {
            if (!TestCheck(color))
            {
                return false;
            }

            foreach (ChessPiece opponentPieces in GetPiecesOnTheBoard(Opponent(color)))
            {
                bool[,] mat = opponentPieces.PossibleMoves();
                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat.Length; j++)
                    {
                        if (mat[i, j])
                        {
                            Position source = opponentPieces.Position;
                            Position target = new Position(i, j);

                            Piece capturedPiece = MakeMove(source, target);
                            bool testCheck = TestCheck(color);
                            UndoMove(source, target, capturedPiece);

                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void PlaceNewPiece(char column, int row, ChessPiece piece)
        {
            Position pos = new ChessPosition(column, row).ToPosition();

            Board.PlacePiece(piece, pos);
            PiecesOnTheBoard.Add(piece);
        }

        private void PlaceInitialPieces()
        {
            //White Pieces
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new King(Board, Color.White, this));
            PlaceNewPiece('e', 1, new Queen(Board, Color.White));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));

            PlaceNewPiece('a', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White));

            //Black Pieces
            PlaceNewPiece('a', 1, new Rook(Board, Color.Red));
            PlaceNewPiece('b', 1, new Knight(Board, Color.Red));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.Red));
            PlaceNewPiece('d', 1, new King(Board, Color.Red, this));
            PlaceNewPiece('e', 1, new Queen(Board, Color.Red));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.Red));
            PlaceNewPiece('g', 1, new Knight(Board, Color.Red));
            PlaceNewPiece('h', 1, new Rook(Board, Color.Red));

            PlaceNewPiece('a', 2, new Pawn(Board, Color.Red));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.Red));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.Red));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.Red));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.Red));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.Red));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.Red));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.Red));
        }
    }
}
