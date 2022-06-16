using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessgame.Entities
{
    class Bishop : Piece
    {
        //Constructors
        public Bishop()
        {
        }

        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "B";
        }
    }
}

