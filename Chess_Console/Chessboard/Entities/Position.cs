using Chess_Console.Chessgame.Entities;

namespace Chess_Console.Chessboard.Entities
{
    class Position
    {
        //Variables
        public int Line { get; private set; }
        public int Column { get; private set; }

        //Constructors
        public Position() 
        {
        }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        //Overrides
        public override string ToString()
        {
            return $"{Line}, {Column}";
        }
    }
}
