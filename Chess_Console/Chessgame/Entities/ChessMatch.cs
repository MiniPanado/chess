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
        public ChessPiece EnPassantVulnerable { get; private set; }
        public ChessPiece Promoted { get; private set; }
        public HashSet<Piece> PiecesOnTheBoard { get; private set; }

        //Constructors
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;

            PiecesOnTheBoard = new HashSet<Piece>();

            PlaceInitialPieces();
        }

        //Methods
        public ChessPiece[,] GetPieces()
        {
            ChessPiece[,] mat = new ChessPiece[Board.Rows, Board.Columns];
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    mat[i, j] = (ChessPiece)Board.GetPiece(i, j);
                }
            }

            return mat;
        }

        public bool[,] PossiblesMoves(ChessPosition sourcePosition)
        {
            Position source = sourcePosition.ToPosition();
            ValidateSourcePosition(source);
            return Board.GetPiece(source).PossibleMoves();
        }

        public ChessPiece PerformsChessMove(ChessPosition sourcePosition, ChessPosition targetPosition)
        {
            Position source = sourcePosition.ToPosition();
            Position target = targetPosition.ToPosition();
            ValidateSourcePosition(source);
            ValidateTargetPosition(source, target);

            Piece capturedPiece = MakeMove(source, target);
            ChessPiece movedPiece = (ChessPiece)Board.GetPiece(target);

            // #specialmove en passant
            if (movedPiece is Pawn && (target.Row == source.Row - 2 || target.Row == source.Row + 2))
            {
                EnPassantVulnerable = movedPiece;
            }
            else
            {
                EnPassantVulnerable = null;
            }

            // #specialmove promotion
            Promoted = null;
            if (movedPiece is Pawn)
            {
                if ((movedPiece.Color == Color.Red && target.Row == 0) || (movedPiece.Color == Color.White && target.Row == 7))
                {
                    Promoted = (ChessPiece)Board.GetPiece(target);
                    Promoted = ReplacePromotedPiece("Q");
                }
            }

            if (TestCheck(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new GameException("You can't put yourself in check");
            }

            Check = TestCheck(Opponent(CurrentPlayer));

            if (TestCheckMate(Opponent(CurrentPlayer))) CheckMate = true;
            
            else NextTurn();

            return (ChessPiece)capturedPiece;
        }

        private ChessPiece ReplacePromotedPiece(string type)
        {
            if (Promoted == null)
            {
                throw new GameException("There is no piece to be promoted");
            }
            if (!type.Equals("B") && !type.Equals("N") && !type.Equals("R") && !type.Equals("Q"))
            {
                return Promoted;
            }

            Position pos = Promoted.Position;
            Piece piece = Board.RemovePiece(pos);
            PiecesOnTheBoard.Remove(piece);

            ChessPiece newPiece = NewPiece(type, Promoted.Color);
            Board.PlacePiece(newPiece, pos);
            PiecesOnTheBoard.Add(newPiece);

            return newPiece;
        }

        private ChessPiece NewPiece(string type, Color color)
        {
            if (type.Equals("B")) return new Bishop(Board, color);
            if (type.Equals("N")) return new Knight(Board, color);
            if (type.Equals("Q")) return new Queen(Board, color);
            return new Rook(Board, color);
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
            }

            // #specialmove castling
            if (piece is King)
            {
                if (target.Column == source.Column + 2)
                {
                    // #specialmove castling kingside rook
                    Position sourceRook = new Position(source.Row, source.Column + 3);
                    Position targetRook = new Position(source.Row, source.Column + 1);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(sourceRook);

                    Board.PlacePiece(rook, targetRook);
                    rook.IncreaseMoveCount();
                }
                else if (target.Column == source.Column - 2)
                {
                    // #specialmove castling queenside rook
                    Position sourceRook = new Position(source.Row, source.Column - 4);
                    Position targetRook = new Position(source.Row, source.Column - 1);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(sourceRook);

                    Board.PlacePiece(rook, targetRook);
                    rook.IncreaseMoveCount();
                }
            }

            // #specialmove en passant
            if (piece is Pawn)
            {
                if (source.Column != target.Column && capturedPiece == null)
                {
                    Position pawnPosition = new Position(0, 0);
                    if (piece.Color == Color.White)
                    {
                        pawnPosition.SetValues(target.Row - 1, target.Column);
                    }
                    else
                    {
                        pawnPosition.SetValues(target.Row + 1, target.Column);
                    }

                    capturedPiece = Board.RemovePiece(pawnPosition);
                    PiecesOnTheBoard.Remove(capturedPiece);
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
                PiecesOnTheBoard.Add(capturedPiece);
            }

            if (piece is King)
            {
                if (target.Column == source.Column + 2)
                {
                    // #specialmove castling kingside rook
                    Position sourceRook = new Position(source.Row, source.Column + 3);
                    Position targetRook = new Position(source.Row, source.Row + 1);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(targetRook);

                    Board.PlacePiece(rook, sourceRook);
                    rook.DecreaseMoveCount();
                }
                else if (target.Column == source.Column - 2)
                {
                    // #specialmove castling queenside rook
                    Position sourceRook = new Position(source.Row, source.Column - 4);
                    Position targetRook = new Position(source.Row, source.Row - 1);
                    ChessPiece rook = (ChessPiece)Board.RemovePiece(targetRook);

                    Board.PlacePiece(rook, sourceRook);
                    rook.DecreaseMoveCount();
                }
            }

            // #specialmove en passant
            if (piece is Pawn)
            {
                if (source.Column != target.Column && capturedPiece == EnPassantVulnerable)
                {
                    ChessPiece pawn = (ChessPiece)Board.RemovePiece(target);
                    Position pawnPosition;
                    if (piece.Color == Color.White)
                    {
                        pawnPosition = new Position(3, target.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(4, target.Column);
                    }
                    Board.PlacePiece(pawn, pawnPosition);
                }
            }
        }

        private void ValidateSourcePosition(Position position)
        {
            //Exceptions
            if (!Board.ThereIsAPiece(position))
            {
                throw new GameException("There is no piece on source position");
            }
            if (CurrentPlayer != ((ChessPiece)Board.GetPiece(position)).Color)
            {
                throw new GameException("The chosen piece is not yours");
            }
            if (!Board.GetPiece(position).IsThereAnyPossibleMove())
            {
                throw new GameException("There is no possible moves for the chosen piece");
            }
        }

        private void ValidateTargetPosition(Position source, Position target)
        {
            //Exceptions
            if (!Board.GetPiece(source).GetPossibleMove(target))
            {
                throw new GameException("The chosen piece can't move to target position");
            }
        }

        private void NextTurn()
        {
            Turn++;
            CurrentPlayer = Opponent(CurrentPlayer);
        }

        private Color Opponent(Color color)
        {
            return (CurrentPlayer == Color.White) ? Color.Red : Color.White;
        }

        private ChessPiece King(Color color)
        {
            foreach (Piece piece in PiecesOnTheBoard)
            {
                if (piece is King && ((ChessPiece)piece).Color == color)
                {
                    return (ChessPiece)piece;
                }
            }

            throw new GameException($"There is no {color} king on the board");
        }

        private bool TestCheck(Color color)
        {
            Position king = King(color).Position;

            foreach (Piece piece in PiecesOnTheBoard)
            {
                if (((ChessPiece)piece).Color != color)
                {
                    bool[,] mat = piece.PossibleMoves();
                    if (mat[king.Row, king.Column])
                    {
                        return true;
                    }
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

            foreach (Piece piece in PiecesOnTheBoard)
            {
                if (((ChessPiece)piece).Color == color)
                {
                    bool[,] mat = piece.PossibleMoves();

                    for (int i = 0; i < Board.Rows; i++)
                    {
                        for (int j = 0; j < Board.Columns; j++)
                        {
                            if (mat[i, j])
                            {
                                Position source = piece.Position;
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
            }

            return true;
        }

        private void PlaceNewPiece(char column, int row, ChessPiece piece)
        {
            Position position = new ChessPosition(column, row).ToPosition();

            Board.PlacePiece(piece, position);
            PiecesOnTheBoard.Add(piece);
        }

        private void PlaceInitialPieces()
        {
            //Black Pieces
            PlaceNewPiece('a', 1, new Rook(Board, Color.Red));
            PlaceNewPiece('b', 1, new Knight(Board, Color.Red));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.Red));
            PlaceNewPiece('d', 1, new Queen(Board, Color.Red));
            PlaceNewPiece('e', 1, new King(Board, Color.Red, this));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.Red));
            PlaceNewPiece('g', 1, new Knight(Board, Color.Red));
            PlaceNewPiece('h', 1, new Rook(Board, Color.Red));

            PlaceNewPiece('a', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.Red, this));

            //White Pieces
            PlaceNewPiece('a', 8, new Rook(Board, Color.White));
            PlaceNewPiece('b', 8, new Knight(Board, Color.White));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 8, new Queen(Board, Color.White));
            PlaceNewPiece('e', 8, new King(Board, Color.White, this));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 8, new Knight(Board, Color.White));
            PlaceNewPiece('h', 8, new Rook(Board, Color.White));

            PlaceNewPiece('a', 7, new Pawn(Board, Color.White, this));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.White, this));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.White, this));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.White, this));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.White, this));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.White, this));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.White, this));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.White, this));
        }
    }
}
