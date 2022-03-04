using System;
using StoreConsoleApp.Interfaces;
using StoreConsoleApp.MenuOptions;
using static StoreConsoleApp.Enums.MenuItem;

namespace StoreConsoleApp.Menu.Menu_Options
{
    public class NewUser : IMenu
    {
        public void ShowMenu(MenuItems item)
        {
            Console.WriteLine($"Your choice: {item.GetDescription()}");
            User.UserRegistration();
        }
    }
}