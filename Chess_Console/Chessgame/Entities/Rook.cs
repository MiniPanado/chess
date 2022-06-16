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
    }
}

