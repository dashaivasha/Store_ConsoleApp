using System;

namespace StoreConsoleApp.Exceptions
{
    public class BasketException : Exception
    {
        public BasketException(string message) : base(message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
    }
}
