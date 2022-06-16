using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessgame.Entities
{
    class Queen : Piece
    {
        //Constructors
        public Queen()
        {
        }

        public Queen(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "Q";
        }
    }
}

