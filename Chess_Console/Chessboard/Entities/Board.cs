namespace Chessboard.Entities
{
    class Board
    {
        //Variables
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; private set; }

        //Constructors
        public Board()
        {
        }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        //Methods
        public void PlacePiece(Piece piece, Position position)
        {
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
