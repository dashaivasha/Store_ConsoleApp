using StoreConsoleApp.Data;
using StoreConsoleApp.Enums;
using StoreConsoleApp.Menu.Menu_Options;
using StoreConsoleApp.Menu.Menu_Options.Profile;
using StoreConsoleApp.Menu.MenuOptions.Basket;
using StoreConsoleApp.Menu.MenuOptions.Store;
using StoreConsoleApp.MenuOptions;
using System;
using static StoreConsoleApp.Enums.AdminMenus;
using static StoreConsoleApp.Enums.MenuItem;

namespace StoreConsoleApp.Menu
{
    public class ConsoleMenuManager
    {
        public static void CheckChoiceAndRun(int actions)
        {
            var consoleMenu = new ConsoleMenu();

            switch (actions)
            {
                case (int)MenuItems.Store:
                    var store = new Store();
                    store.ShowMenu(MenuItems.Store);
                    consoleMenu.ShowMenu();
                    break;
                case (int)MenuItems.Basket:
                    var basket = new BasketMenu();
                    basket.ShowMenu(MenuItems.Basket);
                    consoleMenu.ShowMenu();
                    break;
                case (int)MenuItems.Profile:
                    Profile profile = new Profile();
                    profile.ShowMenu(MenuItems.Profile);
                    consoleMenu.ShowMenu();
                    break;
                case (int)MenuItems.Login:
                    User.LoginUser();
                    consoleMenu.ShowMenu();
                    break;
                case (int)MenuItems.CreateNewUser:
                    NewUser user = new NewUser();
                    user.ShowMenu(MenuItems.CreateNewUser);
                    consoleMenu.ShowMenu();
                    break;
                case (int)MenuItems.Exit:
                    DataManagerJson.ExitCurrentUser();
                    Environment.Exit(0);
                    break;
            }
        }

        public static void CheckChoiceAndRunAdminMenu(int actions)
        {
            var consoleMenu = new ConsoleMenu();

            switch (actions)
            {
                case (int)AdminMenu.ShowProduct:
                    var store = new Store();
                    store.ShowMenu(MenuItems.Store);
                    consoleMenu.ShowMenu();
                    break;
                case (int)AdminMenu.AddProduct:
                    Product.AddProduct();
                    consoleMenu.ShowMenu();
                    break;
                case (int)AdminMenu.DeleteProduct:
                    Product.DeleteProduct();
                    consoleMenu.ShowMenu();
                    break;
                case (int)AdminMenu.ChangeProductPrice:
                    Product.ChangeProduct();
                    consoleMenu.ShowMenu();
                    break;
                case (int)AdminMenu.ShowUsers:
                    User.GetAndShowUsers();
                    consoleMenu.ShowMenu();
                    break;
                case (int)AdminMenu.CreateNewUser:
                    NewUser user = new NewUser();
                    user.ShowMenu(MenuItems.CreateNewUser);
                    consoleMenu.ShowMenu();
                    break;
                case (int)AdminMenu.DeleteUser:
                    User.DeleteUser();
                    consoleMenu.ShowMenu();
                    break;
                case (int)AdminMenu.Exit:
                    DataManagerJson.ExitCurrentUser();
                    Environment.Exit(0);
                    break;
            }
        }

        private static void ShowDefaultValue(Enum menu)
        {
            Console.WriteLine($"Realization *{menu.GetDescription()}* still in progress");
        }
    }
}
