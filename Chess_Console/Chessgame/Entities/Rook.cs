using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessgame.Entities
{
    class Rook : Piece
    {
        //Constructors
        public Rook()
        {
        }

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
            bool[,] mat = new bool[Board.TotalLines, Board.TotalColumns];

            Position pos = new Position();

            //Top
            pos.SetValues(Position.Line - 1, Position.Column);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line - 1, pos.Column);
            }

            //Right
            pos.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line, pos.Column + 1);
            }

            //Bottom
            pos.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line + 1, pos.Column);
            }

            //Left
            pos.SetValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Line, pos.Column - 1);
            }

            return mat;
        }
    }
}

