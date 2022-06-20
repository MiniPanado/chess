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
        public void IncreaseRow()
        {
            Row++;
        }

        public void DecreaseRow()
        {
            Row--;
        }

        public void IncreaseColumn()
        {
            Column++;
        }

        public void DecreaseColumn()
        {
            Column--;
        }

        public void SetValues(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
