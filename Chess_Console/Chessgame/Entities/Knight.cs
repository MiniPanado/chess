using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessgame.Entities
{
    class Knight : Piece
    {
        //Constructors
        public Knight()
        {
        }

        public Knight(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "K";
        }
    }
}

