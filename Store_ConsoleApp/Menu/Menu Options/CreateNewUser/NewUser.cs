using System;
using Store_ConsoleApp.Data;
using Store_ConsoleApp.Interfaces;
using static Console_store.Menu.Enums.MenuItem;

namespace Store_ConsoleApp.Menu.Menu_Options
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