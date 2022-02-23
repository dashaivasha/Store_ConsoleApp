using Store_ConsoleApp.Data;
using Store_ConsoleApp.Interfaces;
using System;
using static Console_store.Menu.Enums.MenuItem;

namespace Store_ConsoleApp.Menu.Menu_Options
{
    public class NewUser : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine($"Your choice: {MenuItems.CreateNewUser}");
            User.UserRegistration();
        }
    }
}