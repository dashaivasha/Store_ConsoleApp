using System;
using StoreConsoleApp.Data;
using StoreConsoleApp.Interfaces;
using static StoreConsoleApp.Enums.MenuItem;

namespace StoreConsoleApp.Menu.MenuOptions.Basket
{
    internal class BasketMenu : IMenu
    {
        public void ShowMenu(MenuItems item)
        {

            if (DataManagerJson.CheckUser())
            {
                Console.WriteLine($"Your choice: {item.GetDescription()}");
                BasketService.FindUserBasket();

            }
        }
    }
}
