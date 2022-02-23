using Store_ConsoleApp.Menu.Menu_Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Console_store.Menu.Enums.MenuItem;

namespace Store_ConsoleApp.Menu
{
    public class ConsoleMenuManager
    {
        public static void CheckChoiseAndRun(int actions)
        {
                switch (actions)
                {
                    case (int)MenuItems.Store:

                        break;
                    case (int)MenuItems.Basket:

                        break;
                    case (int)MenuItems.Profile:
                    //Profile profile = new Profile();
                    //profile.ShowMenu();
                        break;
                    case (int)MenuItems.Login:

                        break;
                    case (int)MenuItems.CreateNewUser:
                    NewUser user = new NewUser();
                    user.ShowMenu();
                        break;
                    case (int)MenuItems.Exit:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

