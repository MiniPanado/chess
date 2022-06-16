namespace Chess_Console.Chessgame.Entities
{
    class ChessPosition
    {
        //Variables
        public char Column { get; private set; }
        public int Line { get; private set; }

        //Constructors
        public ChessPosition()
        {
        }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        //Overrides
        public override string ToString()
        {
            return $"{Column}{Line}";
        }
    }
}
