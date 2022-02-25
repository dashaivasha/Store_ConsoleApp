using System;
using InternshipProject.ConsoleMenu;
using System.Collections.Generic;
using System.IO;
using StoreConsoleApp.Menu.MenuOptions.Store;
using StoreConsoleApp.MenuOptions;

namespace StoreConsoleApp.Data
{
    internal class DataManagerJson
    {

        public static void NewUserToJson(List<User> users)
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\UserData.json";
            DataSerializer.JsonSerialize(users, path);
        }

        public static void CurrentUserToJson(User user)
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\CurrentUser.json";
            DataSerializer.JsonSerialize(user, path);
        }

        public static void ExitCurrentUser()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\CurrentUser.json";
            FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            fileStream.SetLength(0);
            fileStream.Close();
        }

        public static bool CheckUser()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\CurrentUser.json";
            FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);

            if (fileStream.Length == 0)
            {
                fileStream.Close();
                Console.WriteLine("You are not authorized! Please, select the *login* menu item");

                return false;
            }

            fileStream.Close();

            return true;
        }

        public static void NewProductToJson(List<Product> products)
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\ProductData.json";
            DataSerializer.JsonSerialize(products, path);
        }
    }
}
