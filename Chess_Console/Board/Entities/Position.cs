namespace Board.Entities
{
    class Position
    {
        //Variables
        public int Line { get; set; }
        public int Column { get; set; }

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
