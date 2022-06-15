using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
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
