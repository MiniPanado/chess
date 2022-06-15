using Board.Enums;

namespace Board.Entities
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

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            NumberOfMoves = 0;
        }
    }
}
