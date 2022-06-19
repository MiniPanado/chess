using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessboard.Entities
{
    class Piece
    {
        //Variables
        public Board Board { get; private set; }
        public Color Color { get; private set; }
        public Position Position { get; set; }
        public int NumberOfMoves { get; private set; }

        //Constructors
        public Piece()
        {
        }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
        }

        //Methods
        public void IncreaseNumberOfMoves()
        {
            NumberOfMoves++;
        }
    }
}
