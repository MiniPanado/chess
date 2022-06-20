using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class King : Piece
    {
        //Constructors
        public King()
        {
        }

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
            bool[,] mat = new bool[Board.TotalLines, Board.TotalColumns];

            Position pos = new Position();

            //Top right corner
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Top
            pos.SetValues(Position.Line - 1, Position.Column);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Top right corner
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Right
            pos.SetValues(Position.Line, Position.Column + 1);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Bottom right corner
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Bottom
            pos.SetValues(Position.Line + 1, Position.Column);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Bottom left corner
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Left
            pos.SetValues(Position.Line, Position.Column - 1);
            if (!Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
