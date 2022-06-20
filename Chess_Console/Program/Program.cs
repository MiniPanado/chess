using System;
using Chessboard.Entities;
using Chessboard.Exceptions;
using Chessgame.Entities;
using Chessgame.Exceptions;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();
                
                while (!chessMatch.CheckMate)
                {
                    Console.Clear();

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    chessMatch.ValidateOriginPosition(origin);

                    bool[,] possibleMoves = chessMatch.Board.GetPiece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(, possibleMoves);

                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();
                    chessMatch.ValidateDestinationPosition(origin, destination);

                    chessMatch.PerformsMove(origin, destination);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine($"Board Error: {e.Message}");
            }
            catch (GameException e)
            {
                Console.WriteLine($"Game Error: {e.Message}");
            }
        }
    }
}
