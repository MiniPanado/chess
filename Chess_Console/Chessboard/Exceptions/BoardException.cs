using System;

namespace Chess_Console.Chessboard.Exceptions
{
    class BoardException : Exception
    {
        //Constructors
        public BoardException(string message) : base(message)
        {
        }
    }
}
