using Chessboard.Entities;

namespace Chessgame.Entities
{
    class ChessPosition
    {
        //Variables
        public char Column { get; private set; }
        public int Row { get; private set; }

        //Constructors
        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
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
