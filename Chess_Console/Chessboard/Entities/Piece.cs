using Chessboard.Entities;
using Chessgame.Entities;

namespace Chessboard.Entities
{
    abstract class Piece
    {
        //Variables
        public Board Board { get; private set; }
        public Position Position { get; protected set; }

        //Constructors
        public Piece(Board board)
        {
            Board = board;
        }

        //Methods
        public void SetPosition(Position position)
        {
            Position = position;
        }

        public abstract bool[,] PossibleMoves();

        public bool GetPossibleMove(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public bool IsThereAnyPossibleMove()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
