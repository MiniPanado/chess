using Chessboard.Exceptions;

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
            if (position.Line >= 0 && position.Column >= 0 && position.Line < Lines && position.Column < Columns)
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