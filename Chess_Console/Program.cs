using System;
using Chessboard.Entities;
using Chessboard.Exceptions;
using Chessgame.Entities;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board);

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    chessMatch.ExecutesMovement(origin, destination);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine($"Board Error: {e.Message}");
            }
        }
    }
}
