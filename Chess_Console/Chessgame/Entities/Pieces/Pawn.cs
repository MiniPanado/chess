using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Pawn : ChessPiece
    {
        //Constructors
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                //Above Initial
                pos.SetValues(Position.Row - 2, Position.Column);
                if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos) && MoveCount == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Above
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Top Right Corner
                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Top Left Corner
                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }    
            }
            else
            {
                //Bellow Initial
                pos.SetValues(Position.Row + 2, Position.Column);
                if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos) && MoveCount == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Bellow
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Bottom Right Corner
                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Bottom Left Corner
                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}