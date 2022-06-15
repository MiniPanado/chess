using Chessboard.Enums;

namespace Chessboard.Entities
{
    class Piece
    {
        //Variables
        public Board Board { get; protected set; }
        public Color Color { get; protected set; }
        public Position Position { get; set; }
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
