using System;

namespace Chessboard.Exceptions
{
    class BoardException : Exception
    {
        //Constructors
        public BoardException(string message) : base(message)
        {
        }
    }
}
