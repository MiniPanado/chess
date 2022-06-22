using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class King : ChessPiece
    {
        private ChessMatch ChessMatch;

        //Constructors
        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        //Overrides
        public override string ToString()
        {
            return "K";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Top right corner
            pos.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Top
            pos.SetValues(Position.Row - 1, Position.Column);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Top right corner
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Right
            pos.SetValues(Position.Row, Position.Column + 1);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom right corner
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom
            pos.SetValues(Position.Row + 1, Position.Column);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom left corner
            pos.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Left
            pos.SetValues(Position.Row, Position.Column - 1);
            if (Board.PositionExists(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // #specialmove castling
            if (MoveCount == 0 && !ChessMatch.Check)
            {
                // #specialmove castling kingside rook
                Position posRook1 = new Position(Position.Row, Position.Column + 3);
                if (TestRookCastling(posRook1))
                {
                    Position pos1 = new Position(Position.Row, Position.Column + 1);
                    Position pos2 = new Position(Position.Row, Position.Column + 2);

                    if (Board.GetPiece(pos1) == null && Board.GetPiece(pos2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }

                // #specialmove castling queenside rook
                Position posRook2 = new Position(Position.Row, Position.Column - 4);
                if (TestRookCastling(posRook2))
                {
                    Position pos1 = new Position(Position.Row, Position.Column - 1);
                    Position pos2 = new Position(Position.Row, Position.Column - 2);
                    Position pos3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.GetPiece(pos1) == null && Board.GetPiece(pos2) == null && Board.GetPiece(pos3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

        //Methods
        private bool CanMove(Position position)
        {
            ChessPiece piece = (ChessPiece)Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        private bool TestRookCastling(Position position)
        {
            ChessPiece piece = (ChessPiece)Board.GetPiece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.MoveCount == 0;
        }
    }
}
