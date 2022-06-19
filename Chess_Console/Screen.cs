using System;
using Chess_Console.Chessboard.Entities;
using Chess_Console.Chessboard.Enums;
using Chess_Console.Chessgame.Entities;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.TotalLines; i++)
            {
                Console.Write($"{board.TotalColumns - i} ");
                for (int j = 0; j < board.TotalColumns; j++)
                {
                    if (board.Pieces[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Pieces[i, j]);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        private static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(piece);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(piece);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static Position ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(column, line).ToPosition();
        }
    }
}
