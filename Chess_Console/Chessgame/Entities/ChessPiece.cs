using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    abstract class ChessPiece : Piece
    {
        //Variables
        public Color Color { get; private set; }
        public int MoveCount { get; private set; }

        //Constructors
        public ChessPiece(Board board, Color color) : base(board)
        {
            Color = color;
        }

        //Methods
        public void IncreaseMoveCount()
        {
            MoveCount++;
        }

        public void DecreaseMoveCount()
        {
            MoveCount--;
        }

        public ChessPosition GetChessPosition()
        {
            return ChessPosition.FromPosition(Position);
        }

        //Methods bool
        protected bool IsThereOpponentPiece(Position position)
        {
            ChessPiece chessPiece = (ChessPiece)Board.GetPiece(position);
            return chessPiece != null && chessPiece.Color != Color;
        }
    }
}
