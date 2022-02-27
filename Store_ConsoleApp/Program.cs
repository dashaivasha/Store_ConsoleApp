using StoreConsoleApp.Menu;

namespace StoreConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu consoleMenu = new();
            consoleMenu.ShowMenu();
        }
    }
}
