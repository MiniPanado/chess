using System;
using System.Collections.Generic;
using Chessboard.Exceptions;
using Chessgame.Entities;
using Chessgame.Exceptions;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch chessMatch = new ChessMatch();
            HashSet<ChessPiece> capturedPieces = new HashSet<ChessPiece>();

            while (!chessMatch.CheckMate)
            {
                try
                {
                    Console.Clear();
                    UI.PrintChessMatch(chessMatch, capturedPieces);

                    Console.Write("\nSource: ");
                    ChessPosition source = UI.ReadChessPosition();

                    bool[,] possibleMoves = chessMatch.GetPossiblesMoves(source);
                    ChessPiece[,] pieces = chessMatch.GetPieces();

                    Console.Clear();
                    UI.PrintBoard(pieces, possibleMoves);

                    Console.Write("\nTarget: ");
                    ChessPosition target = UI.ReadChessPosition();

                    ChessPiece capturedPiece = chessMatch.PerformsChessMove(source, target);

                    if (capturedPiece != null)
                    {
                        capturedPieces.Add(capturedPiece);
                    }
                }
                catch (BoardException e)
                {
                    Console.WriteLine($"Board Error: {e.Message}");
                    Console.ReadKey();
                }
                catch (GameException e)
                {
                    Console.WriteLine($"Game Error: {e.Message}");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            UI.PrintChessMatch(chessMatch, capturedPieces);
            Console.ReadKey();
        }
    }
}