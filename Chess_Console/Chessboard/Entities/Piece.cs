using Chessboard.Enums;

namespace Chessboard.Entities
{
    class Piece
    {
        //Variables
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int NumberOfMoves { get; protected set; }

        //Constructors
        public Piece()
        {
        }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
        }
    }
}
