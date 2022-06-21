﻿using System;
using System.Collections.Generic;
using Chessboard.Entities;
using Chessboard.Enums;
using Chessgame.Entities;

namespace Program
{
    class UI
    {
        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(column, line);
        }

        public static void PrintChessMatch(ChessMatch chessMatch)
        {
            UI.PrintBoard(chessMatch);
            PrintCapturedPieces(chessMatch);
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
            }
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{board.Rows - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece((ChessPiece)board.GetPiece(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
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

                    PrintPiece((ChessPiece)board.GetPiece(i, j));
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

        private static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintCapturedPiecesSets(match.GetCapturedPieces(Color.White));

            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCapturedPiecesSets(match.GetCapturedPieces(Color.Red));
            Console.ForegroundColor = ConsoleColor.Gray;
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
    }
}