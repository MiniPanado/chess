using System;

namespace Chessgame.Exceptions
{
    class GameException : Exception
    {
        //Constructors
        public GameException(string message) : base(message)
        {
        }
    }
}
