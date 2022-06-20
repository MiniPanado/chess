using Chessboard.Entities;

namespace Chessgame.Entities
{
    class ChessPosition
    {
        //Variables
        public char Column { get; private set; }
        public int Row { get; private set; }

        //Constructors
        public ChessPosition()
        {
        }

        public ChessPosition(char column, int row)
        {
            if (column < 'a' || column > 'h' || row < 1 || row > 8)

            Column = column;
            Row = row;
        }

        //Overrides
        public override string ToString()
        {
            return $"{Column}{Row}";
        }

        //Methods
        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public static ChessPosition FromPosition(Position position)
        {
            return new ChessPosition((char)('a' + position.Column), 8 - position.Row);
        }
    }
}
