using StoreConsoleApp.Data;
using StoreConsoleApp.Interfaces;
using StoreConsoleApp.MenuOptions;
using System;
using static Console_store.Menu.Enums.MenuItem;

namespace StoreConsoleApp.Menu.Menu_Options.Profile
{
    internal class Profile : IMenu
    {
        public void ShowMenu(MenuItems item)
        {
            if (DataManagerJson.CheckUser())
            {
                Console.WriteLine($"Your choice: {item.GetDescription()}");
                var user = User.GetUser();
                Console.WriteLine($"Your data:\nLogin: {user.Login} \nEmail: {user.Email}");
            }
        }
    }
}
