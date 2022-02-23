using Store_ConsoleApp.Menu;
using System;

namespace Store_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu consoleMenu = new();
            consoleMenu.ShowMenu();
        }
    }
}
