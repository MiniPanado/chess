using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
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

