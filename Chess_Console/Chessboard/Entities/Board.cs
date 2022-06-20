using Chess_Console.Chessboard.Exceptions;

namespace Chess_Console.Chessboard.Entities
{
    class Board
    {
        //Variables
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Piece[,] Pieces { get; private set; }

        //Constructors
        public Board()
        {
        }

        public Board(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new BoardException("Error creating board: there must be at least 1 row and 1 column");
            }

            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        //Methods
        public Piece GetPiece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public Piece GetPiece(int row, int column)
        {
            return Pieces[row, column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            //Exceptions
            if (ThereIsAPiece(position))
            {
                throw new BoardException("There is already a piece on position " + position);
            }
            if (!PositionExists(position))
            {
                throw new BoardException("Position not on the board");
            }

            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            //Exceptions
            if (!PositionExists(position))
            {
                throw new BoardException("Position not on the board");
            }

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

        //Methods Exceptions
        private bool PositionExists(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        public bool PositionExists(Position position)
        {
            return PositionExists(position.Line, position.Column);
        }

        public bool ThereIsAPiece(Position position)
        {
            return GetPiece(position) != null;
        }
    }
}