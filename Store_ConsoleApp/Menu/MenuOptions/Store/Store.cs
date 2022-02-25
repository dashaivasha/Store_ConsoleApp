using StoreConsoleApp.Data;
using StoreConsoleApp.Interfaces;
using StoreConsoleApp.Menu.MenuOptions.Store;
using System;
using static Console_store.Menu.Enums.MenuItem;

namespace StoreConsoleApp.Menu.Menu_Options.Profile
{
    internal class Store : IMenu
    {
        public void ShowMenu(MenuItems item)
        {
                Console.WriteLine($"Your choice: {item.GetDescription()}");
                Product.GetAndShowProducts();
        }
    }
}
