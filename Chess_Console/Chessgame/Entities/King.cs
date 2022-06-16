using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessgame.Entities
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
    }
}
