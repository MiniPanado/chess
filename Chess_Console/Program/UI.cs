using System;
using System.Collections.Generic;
using Chessboard.Enums;
using Chessgame.Entities;
using Chessgame.Exceptions;

namespace Program
{
    class UI
    {
        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();

            //Exceptions
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new GameException("Enter a non-null value");
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
            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    PrintPiece(pieces[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(ChessPiece[,] pieces, bool[,] possibleMoves)
        {
            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    PrintPiece(pieces[i, j]);
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
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
            PrintCollection(whitePieces);

            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCollection(blackPieces);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
