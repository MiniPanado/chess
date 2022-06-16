using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessboard.Entities
{
    class Piece
    {
        //Variables
        public Board Board { get; set; }
        public Color Color { get; set; }
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
