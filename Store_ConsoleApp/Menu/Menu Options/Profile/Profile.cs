using Store_ConsoleApp.Data;
using Store_ConsoleApp.Interfaces;
using System;
using static Console_store.Menu.Enums.MenuItem;

namespace Store_ConsoleApp.Menu.Menu_Options.Profile
{
    internal class Profile : IMenu
    {
        public void ShowMenu(MenuItems item)
        {
            if (DataManagerJson.CheckUser() == true)
            {
                Console.WriteLine($"Your choice: {item.GetDescription()}");
                var user = User.GetUser();
                Console.WriteLine($"Your data:\nLogin: {user.Login} \nEmail: {user.Email}");
            }
        }
    }
}