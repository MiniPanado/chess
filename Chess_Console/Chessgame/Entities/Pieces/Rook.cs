using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Rook : ChessPiece
    {
        //Constructors
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            //Above
            pos.SetValues(Position.Row - 1, Position.Column);
            while(Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetRow(pos.Row - 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Right
            pos.SetValues(Position.Row, Position.Column + 1);
            while (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetColumn(pos.Column + 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Bellow
            pos.SetValues(Position.Row + 1, Position.Column);
            while (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetRow(pos.Row + 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Left
            pos.SetValues(Position.Row, Position.Column - 1);
            while (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
                pos.SetColumn(pos.Column - 1);
            }
            if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}

