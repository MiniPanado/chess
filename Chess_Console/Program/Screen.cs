using System;
using System.Collections.Generic;
using Chessboard.Entities;
using Chessboard.Enums;
using Chessgame.Entities;

namespace Program
{
    class Screen
    {
        public static void PrintChessMatch(ChessMatch chessMatch)
        {
            Screen.PrintBoard(chessMatch.Board);
            Console.WriteLine($"\nTurn: {chessMatch.Turn}");
            Console.WriteLine($"\nAwaiting move: {chessMatch.CurrentPlayer}");
        }

        public static void PrintBoard()
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{board.Rows - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece();
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(, bool[,] possibleMoves)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{board.Rows - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    PrintPiece();
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        private static void PrintCapturedPiecesSets(HashSet<Piece> capturedPieces)
        {
            Console.Write("[");
            foreach (Piece capturedPiece in capturedPieces)
            {
                Console.Write($"{capturedPiece} ");
            }
            Console.WriteLine("]");
        }

        private static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintCapturedPiecesSets(chessMatch.GetCapturedPieces(Color.White));

            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCapturedPiecesSets(chessMatch.GetCapturedPieces(Color.Red));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void PrintPiece(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (chessPiece.Color == Color.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(chessPiece);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(chessPiece);
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
