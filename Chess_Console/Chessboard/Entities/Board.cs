using Chess_Console.Chessboard.Exceptions;

namespace Chess_Console.Chessboard.Entities
{
    class Board
    {
        //Variables
        public int TotalLines { get; private set; }
        public int TotalColumns { get; private set; }
        public Piece[,] Pieces { get; private set; }

        //Constructors
        public Board()
        {
        }

        public Board(int totalLines, int totalColumns)
        {
            TotalLines = totalLines;
            TotalColumns = totalColumns;
            Pieces = new Piece[totalLines, totalColumns];
        }

        //Methods
        public Piece GetPiece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            //Exceptions
            if (position.Line < 0 || position.Column < 0 || position.Line >= TotalLines || position.Column >= TotalColumns)
            {
                throw new BoardException("Invalid position!");
            }
            if (GetPiece(position) != null)
            {
                throw new BoardException("There is already a piece in this position!");
            }

            piece.Position = position;
            Pieces[position.Line, position.Column] = piece;
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPiece(position) == null)
            {
                return null;
            }
            else
            {
                Piece capturedPiece = GetPiece(position);
                capturedPiece.Position = null;
                Pieces[position.Line, position.Column] = null;

                return capturedPiece;
            }
        }
    }
}