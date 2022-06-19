using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;

namespace Chess_Console.Chessgame.Entities
{
    class ChessMatch
    {
        //Variables
        public Board Board { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public int Turn { get; private set; }
        public bool Finished { get; private set; }

        //Constructors
        public ChessMatch()
        {
            Board = new Board(8, 8);
            CurrentPlayer = Color.White;
            Turn = 1;

            PlaceInitialPieces();
        }

        //Methods
        public void ExecutesMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseNumberOfMoves();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);
        }

        private void PlaceInitialPieces()
        {
            //White Pieces
            Board.PlacePiece(new Rook(Board, Color.White), new Position(0, 0));
            Board.PlacePiece(new Knight(Board, Color.White), new Position(0, 1));
            Board.PlacePiece(new Bishop(Board, Color.White), new Position(0, 2));
            Board.PlacePiece(new King(Board, Color.White), new Position(0, 3));
            Board.PlacePiece(new Queen(Board, Color.White), new Position(0, 4));
            Board.PlacePiece(new Bishop(Board, Color.White), new Position(0, 5));
            Board.PlacePiece(new Knight(Board, Color.White), new Position(0, 6));
            Board.PlacePiece(new Rook(Board, Color.White), new Position(0, 7));

            for (int i = 0; i < 8; i++)
            {
                Board.PlacePiece(new Pawn(Board, Color.White), new Position(1, i));
            }

            //Red Pieces
            Board.PlacePiece(new Rook(Board, Color.Red), new Position(7, 0));
            Board.PlacePiece(new Knight(Board, Color.Red), new Position(7, 1));
            Board.PlacePiece(new Bishop(Board, Color.Red), new Position(7, 2));
            Board.PlacePiece(new King(Board, Color.Red), new Position(7, 3));
            Board.PlacePiece(new Queen(Board, Color.Red), new Position(7, 4));
            Board.PlacePiece(new Bishop(Board, Color.Red), new Position(7, 5));
            Board.PlacePiece(new Knight(Board, Color.Red), new Position(7, 6));
            Board.PlacePiece(new Rook(Board, Color.Red), new Position(7, 7));

            for (int i = 0; i < 8; i++)
            {
                Board.PlacePiece(new Pawn(Board, Color.Red), new Position(6, i));
            }
        }
    }
}
