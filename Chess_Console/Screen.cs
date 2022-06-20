using System;
using Chessboard.Entities;
using Chessboard.Enums;
using Chessgame.Entities;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{board.Rows - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        private static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(piece);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Write(" ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(column, line);
        }
    }
}
