using System;
using StoreConsoleApp.Data;
using StoreConsoleApp.Interfaces;
using StoreConsoleApp.MenuOptions;
using static StoreConsoleApp.Enums.MenuItem;

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