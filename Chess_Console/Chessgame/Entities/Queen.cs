using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
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

