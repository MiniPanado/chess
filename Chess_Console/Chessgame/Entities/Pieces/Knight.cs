using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Knight : ChessPiece
    {
        //Constructors
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

