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
                Console.WriteLine("Enter *1* - to remove product from the basket.\n" +
                                 "To continue enter any character");
                var userChoice = Convert.ToInt32(Console.ReadLine());
                if (userChoice == 1)
                {
                    BasketService.DeleteProductFromBasket();
                }
            }
        }
    }
}
