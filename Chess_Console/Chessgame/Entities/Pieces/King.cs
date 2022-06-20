using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class King : ChessPiece
    {
        //Constructors
        public King(Board board, Color color) : base(board, color)
        {
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

            return mat;
        }
    }
}
