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
        public void PlacePiece(Piece piece, Position position)
        {
            //Exceptions
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
            if (!AvailablePosition(position))
            {
                throw new BoardException("There is already a piece in this position!");
            }

            piece.Position = position;
            Pieces[position.Line, position.Column] = piece;
        }

        //Methods Exceptions
        #region Validate Position
        private bool ValidPosition(Position position)
        {
            if (position.Line >= 0 && position.Column >= 0 && position.Line < TotalLines && position.Column < TotalColumns)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AvailablePosition(Position position)
        {
            if (Pieces[position.Line, position.Column] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}