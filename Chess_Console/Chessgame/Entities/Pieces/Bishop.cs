using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Bishop : ChessPiece
    {
        //Constructors
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Top Right Corner
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetValues(pos.Row - 1, pos.Column + 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom Right Corner
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetValues(pos.Row + 1, pos.Column + 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom Left Corner
            pos.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetValues(pos.Row + 1, pos.Column - 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Top Left Corner
            pos.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetValues(pos.Row - 1, pos.Column - 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}

