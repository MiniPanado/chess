using System;
using LayerBoard.Entities;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Screen.PrintBoard(board);
            Console.WriteLine("Hello World!");
        }
    }
}
