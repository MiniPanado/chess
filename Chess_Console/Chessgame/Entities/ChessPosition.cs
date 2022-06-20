using Chessboard.Entities;

namespace Chessgame.Entities
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

        //Methods
        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
    }
}
