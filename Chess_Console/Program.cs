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
                int i = 1;
                while (i > 0)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board);
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    chessMatch.MakeMove(origin, destination);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine($"Board Error: {e.Message}");
            }
        }
    }
}
