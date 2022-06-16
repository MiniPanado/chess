using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessgame.Entities
{
    class Pawn : Piece
    {
        //Constructors
        public Pawn()
        {
        }

        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "P";
        }
    }
}

