using StoreConsoleApp.Data;
using StoreConsoleApp.Interfaces;
using StoreConsoleApp.Menu.MenuOptions.Basket;
using StoreConsoleApp.Menu.MenuOptions.Store;
using System;
using static StoreConsoleApp.Enums.MenuItem;

namespace StoreConsoleApp.Menu.Menu_Options.Store
{
    internal class Store : IMenu
    {
        public void ShowMenu(MenuItems item)
        {
            Console.WriteLine($"Your choice: {item.GetDescription()}");
            Product.GetAndShowProducts();

            if (DataManagerJson.CheckUser())
            {
                Console.WriteLine("Enter *1* to add some product to your cart \nTo exit - enter *2* ");
                var userChoice = Convert.ToInt32(Console.ReadLine());
                int iteration = 1;

                do
                {
                    if (userChoice == 2)
                    {
                        break;
                    }

                    if (userChoice == 1)
                    {
                        BasketService.AddingProductToBasket();
                    }

                    Console.WriteLine("If you want to finish adding, enter *2* \nTo continue, enter *1*");
                    int finish = Convert.ToInt32(Console.ReadLine());

                    if (finish == 2)
                    {
                        ++iteration;
                    }
                }
                while (iteration == 1);
            }
        }
    }
}