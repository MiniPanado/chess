using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Knight : ChessPiece
    {
        //Constructors
        public Knight(Board board, Color color) : base(board, color)
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

            //Top Right Corner
            pos.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Top Midle Right Corner
            pos.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom Midle Right Corner
            pos.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom Right Corner
            pos.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom Left Corner
            pos.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bottom Midle Left Corner
            pos.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Top Midle Left Corner
            pos.SetValues(Position.Row - 1, Position.Column - 2);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Top Left Corner
            pos.SetValues(Position.Row - 2, Position.Column - 1);
            if (Board.PositionExists(pos) && !IsThereTeamPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}