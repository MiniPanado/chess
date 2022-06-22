using Chessboard.Exceptions;

namespace Chessboard.Entities
{
    class Board
    {
        //Variables
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Piece[,] Pieces { get; private set; }

        //Constructors
        public Board(int rows, int columns)
        {
            //Exceptions
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
            //Exceptions
            if (!PositionExists(position))
            {
                throw new BoardException("Position not on the board");
            }

            return Pieces[position.Row, position.Column];
        }

        public Piece GetPiece(int row, int column)
        {
            //Exceptions
            if (!PositionExists(row, column))
            {
                throw new BoardException("Position not on the board");
            }

            return Pieces[row, column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            //Exceptions
            if (!PositionExists(position))
            {
                throw new BoardException("Position not on the board");
            }
            if (ThereIsAPiece(position))
            {
                throw new BoardException("There is already a piece on position " + position);
            }

            Pieces[position.Row, position.Column] = piece;
            piece.SetPosition(position);
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

            Piece capturedPiece = GetPiece(position);
            capturedPiece.SetPosition(null);
            Pieces[position.Row, position.Column] = null;

            return capturedPiece;
        }

        //Methods
        private bool PositionExists(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        public bool PositionExists(Position position)
        {
            return PositionExists(position.Row, position.Column);
        }

        public bool ThereIsAPiece(Position position)
        {
            if (!PositionExists(position))
            {
                throw new BoardException("Position not on the board");
            }

            return GetPiece(position) != null;
        }
    }
}