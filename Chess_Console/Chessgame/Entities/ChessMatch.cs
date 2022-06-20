using System.Collections.Generic;
using Chessboard.Entities;
using Chessboard.Enums;
using Chessgame.Exceptions;

namespace Chessgame.Entities
{
    class ChessMatch
    {
        //Variables
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }

        private List<Piece> PiecesOnTheBoard = new List<Piece>();
        private List<Piece> CapturedPieces = new List<Piece>();

        //Constructors
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;

            PlaceInitialPieces();
        }

        //Methods
        private void MakeMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Red;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            //Exceptions
            if (Board.GetPiece(position) == null)
            {
                throw new GameException("There is no piece in the chosen origin position");
            }
            if (!Board.GetPiece(position).IsThereAnyPossibleMove())
            {
                throw new GameException("There are no movements possible for the piece of origin chosen!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            //Exceptions
            if (Board.GetPiece(origin).GetPossibleMove(destination))
            {
                throw new GameException("Invalid destination position!");
            }
        }

        public void PerformsMove(Position origin, Position destination)
        {
            MakeMove(origin, destination);
            Turn++;
        }

        private void PlaceInitialPieces()
        {
            //White Pieces
            Board.PlacePiece(new Rook(Board, Color.White), new Position(0, 0));
            
        }
    }
}
