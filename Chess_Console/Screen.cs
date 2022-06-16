using System;
using Chess_Console.Chessboard.Entities;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.TotalLines; i++)
            {
                for (int j = 0; j < board.TotalColumns; j++)
                {
                    if (board.Pieces[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{board.Pieces[i, j]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
