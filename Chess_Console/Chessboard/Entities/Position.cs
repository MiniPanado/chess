using Chessgame.Entities;

namespace Chessboard.Entities
{
    class Position
    {
        //Variables
        public int Row { get; private set; }
        public int Column { get; private set; }

        //Constructors
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        //Overrides
        public override string ToString()
        {
            return $"{Row}, {Column}";
        }

        //Methods
        public void SetRow(int row)
        {
            Row = row;
        }

        public void SetColumn(int column)
        {
            Column = column;
        }

        public void SetValues(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
