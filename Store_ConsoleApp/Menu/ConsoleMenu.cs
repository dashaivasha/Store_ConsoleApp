using Store_ConsoleApp.Interfaces;
using System;
using System.Text;
using static Console_store.Menu.Enums.MenuItem;

namespace Store_ConsoleApp.Menu
{
    public class ConsoleMenu : IMenu
    {
        private static int _userChoice;
        public void ShowMenu()
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Please enter a number to choose your action");
                var indexOfChoise = 1;
                StringBuilder stringBuilder = new StringBuilder();

                foreach (MenuItems action in MenuItems.GetValues(typeof(MenuItems)))
                {
                    stringBuilder.Append(indexOfChoise++ + " - " + action.GetDescription() + "\n");
                }

                Console.WriteLine(stringBuilder.ToString());
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                _userChoice = Convert.ToInt32(Console.ReadLine());
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
            try
            {
                ConsoleMenuManager.CheckChoiseAndRun(_userChoice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ShowMenu();
            }
        }
    }
}