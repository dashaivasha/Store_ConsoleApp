using System;
using StoreConsoleApp.Data;
using StoreConsoleApp.Interfaces;
using StoreConsoleApp.MenuOptions;
using static Console_store.Menu.Enums.MenuItem;

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
