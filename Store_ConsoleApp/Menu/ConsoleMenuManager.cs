using System;
using Store_ConsoleApp.Data;
using Store_ConsoleApp.Menu.Menu_Options;
using Store_ConsoleApp.Menu.Menu_Options.Profile;
using static Console_store.Menu.Enums.MenuItem;

namespace Store_ConsoleApp.Menu
{
    public class ConsoleMenuManager
    {
        public static void CheckChoiseAndRun(int actions)
        {
            ConsoleMenu consoleMenu = new();

            switch (actions)
            {

                case (int)MenuItems.Store:
                    ShowDefaultValue(MenuItems.Store);
                    consoleMenu.ShowMenu();
                    break;
                case (int)MenuItems.Basket:
                    ShowDefaultValue(MenuItems.Basket);
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

        private static void ShowDefaultValue(MenuItems menu)
        {
            Console.WriteLine($"Realization *{menu.GetDescription()}* still in progress");
        }
    }
}