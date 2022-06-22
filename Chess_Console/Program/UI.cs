using System;
using System.Collections.Generic;
using Chessboard.Enums;
using Chessgame.Entities;
using Chessgame.Exceptions;

namespace Program
{
    class UI
    {
        private static ConsoleColor DefaultForegroundColor = ConsoleColor.Gray;
        private static ConsoleColor ContrastColor = ConsoleColor.Yellow;
        private static ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;
        private static ConsoleColor PossibleMovesColor = ConsoleColor.DarkGray;

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();

            //Exceptions
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new GameException("Enter a non-null value");
            }
            if (s.Length < 2)
            {
                throw new GameException("You have to declare a column and a row");
            }
            if (!int.TryParse(s[1].ToString(), out _))
            {
                throw new GameException("The row has to be an integer");
            }

            char column = s[0];
            int row = int.Parse(s[1].ToString());

            //Exceptions
            if (column < 'a' || column > 'h' || row < 1 || row > 8)
            {
                throw new GameException("Valid values are from a1 to h8.");
            }

            return new ChessPosition(column, row);
        }

        public static void PrintChessMatch(ChessMatch chessMatch, HashSet<ChessPiece> capturedPieces)
        {
            UI.PrintBoard(chessMatch.GetPieces());
            PrintCapturedPieces(capturedPieces);
            Console.WriteLine($"\nTurn: {chessMatch.Turn}");

            if (!chessMatch.CheckMate)
            {
                Console.WriteLine($"Awaiting player: {chessMatch.CurrentPlayer}");

                if (chessMatch.Check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine($"Winner: {chessMatch.CurrentPlayer}");
            }
        }

        private static void PrintBoard(ChessPiece[,] pieces)
        {
            int rows = pieces.GetLength(0);
            int columns = pieces.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = ContrastColor;
                Console.Write($"{rows - i} ");
                Console.ForegroundColor = DefaultForegroundColor;

                for (int j = 0; j < columns; j++)
                {
                    PrintPiece(pieces[i, j]);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ContrastColor;
            Console.Write(" ");
            for (int i = 0; i < columns; i++)
            {
                char c = (char)('a' + i);
                Console.Write($" {c}");
            }
            Console.ForegroundColor = DefaultForegroundColor;
            Console.WriteLine();
        }

        public static void PrintBoard(ChessPiece[,] pieces, bool[,] possibleMoves)
        {
            int rows = pieces.GetLength(0);
            int columns = pieces.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = ContrastColor;
                Console.Write($"{rows - i} ");
                Console.ForegroundColor = DefaultForegroundColor;

                for (int j = 0; j < columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = PossibleMovesColor;
                    }
                    else
                    {
                        Console.BackgroundColor = DefaultBackgroundColor;
                    }

                    PrintPiece(pieces[i, j]);
                }

                Console.BackgroundColor = DefaultBackgroundColor;
                Console.WriteLine();
            }

            Console.ForegroundColor = ContrastColor;
            Console.Write(" ");
            for (int i = 0; i < columns; i++)
            {
                char c = (char)('a' + i);
                Console.Write($" {c}");
            }
            Console.ForegroundColor = DefaultForegroundColor;
            Console.WriteLine();
        }

        private static void PrintPiece(ChessPiece piece)
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
                    Console.ForegroundColor = DefaultForegroundColor;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = DefaultForegroundColor;
                }

                Console.Write(" ");
            }
        }

        private static void PrintCollection(HashSet<ChessPiece> capturedPieces)
        {
            Console.Write("[");
            foreach (ChessPiece capturedPiece in capturedPieces)
            {
                Console.Write($"{capturedPiece} ");
            }
            Console.WriteLine("]");
        }

        private static void PrintCapturedPieces(HashSet<ChessPiece> capturedPieces)
        {
            HashSet<ChessPiece> whitePieces = new HashSet<ChessPiece>();
            HashSet<ChessPiece> blackPieces = new HashSet<ChessPiece>();

            foreach (ChessPiece piece in capturedPieces)
            {
                if (piece.Color == Color.White)
                {
                    whitePieces.Add(piece);
                }
                else
                {
                    blackPieces.Add(piece);
                }
            }

            Console.WriteLine("\nCaptured pieces: ");
            Console.Write("White: ");
            Console.ForegroundColor = ConsoleColor.White;
            PrintCollection(whitePieces);
            Console.ForegroundColor = DefaultForegroundColor;

            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCollection(blackPieces);
            Console.ForegroundColor = DefaultForegroundColor;
        }
    }
}
