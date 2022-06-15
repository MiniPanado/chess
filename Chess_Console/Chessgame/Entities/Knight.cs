using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
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

