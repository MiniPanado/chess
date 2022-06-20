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
        public abstract bool[,] PossibleMoves();

        public bool GetPossibleMove(Position position)
        {
            return PossibleMoves()[Position.Row, Position.Column];
        }

        public bool IsThereAnyPossibleMove()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat.Length; j++)
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
