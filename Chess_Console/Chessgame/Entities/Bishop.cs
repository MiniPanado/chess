using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
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

