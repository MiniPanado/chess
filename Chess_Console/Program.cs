using System;
using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;
using Chess_Console.Chessboard.Exceptions;
using Chess_Console.Chessgame.Entities;

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
                    Position origin = Screen.ReadChessPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition();

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
