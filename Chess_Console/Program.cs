using System;
using Chessboard.Entities;
using Chessboard.Enums;
using Chessgame.Entities;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.PlacePiece(new King(board, Color.White), new Position(0, 3));
            board.PlacePiece(new King(board, Color.Black), new Position(7, 3));

            Screen.PrintBoard(board);

            Console.ReadKey();
        }
    }
}
