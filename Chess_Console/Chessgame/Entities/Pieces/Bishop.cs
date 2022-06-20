using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Bishop : ChessPiece
    {
        //Variables
        private ChessMatch ChessMatch;

        //Constructors
        public Bishop(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        //Overrides
        public override string ToString()
        {
            return "B";
        }
    }
}

