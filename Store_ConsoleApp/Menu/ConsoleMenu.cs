using System;
using System.Text;
using static Console_store.Menu.Enums.MenuItem;
using StoreConsoleApp.Menu;
using StoreConsoleApp.Data;
using StoreConsoleApp.MenuOptions;
using static StoreConsoleApp.Enums.AdminMenus;

namespace Store_ConsoleApp.Menu
{
    public class ConsoleMenu
    {
        private static int _userChoice;

        public void ShowMenu()
        {
            try
            {
                if (DataManagerJson.CheckUser() == false)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Please enter a number to choose your action");
                    var indexOfChoice = 1;
                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (MenuItems action in MenuItems.GetValues(typeof(MenuItems)))
                    {
                        stringBuilder.Append(indexOfChoice++ + " - " + action.GetDescription() + "\n");
                    }

                    Console.WriteLine(stringBuilder.ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    _userChoice = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        ConsoleMenuManager.CheckChoiceAndRun(_userChoice);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        ShowMenu();
                    }
                }
                else
                if (User.CheckIsUserAdmin())
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Please enter a number to choose your action");
                    var indexChoice = 1;
                    StringBuilder stringBuilderAdmin = new StringBuilder();

                    foreach (AdminMenu action in AdminMenu.GetValues(typeof(AdminMenu)))
                    {
                        stringBuilderAdmin.Append(indexChoice++ + " - " + action.GetDescription() + "\n");
                    }

                    Console.WriteLine(stringBuilderAdmin.ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    _userChoice = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        ConsoleMenuManager.CheckChoiceAndRunAdminMenu(_userChoice);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        ShowMenu();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"IndexOutOfRangeException: Wrong case number, select from 1 to {Enum.GetValues(typeof(MenuItems)).Length}");
                ShowMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ShowMenu();
            }
        }
    }
}