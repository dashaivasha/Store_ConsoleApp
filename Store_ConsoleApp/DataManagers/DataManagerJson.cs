using System;
using StoreConsoleApp.Menu.MenuOptions.Basket;
using StoreConsoleApp.Menu.MenuOptions.Store;
using StoreConsoleApp.MenuOptions;
using System.Collections.Generic;
using System.IO;

namespace StoreConsoleApp.Data
{
    internal class DataManagerJson
    {
        public static void NewUserToJson(List<User> users)
        {
            DataSerializer.JsonSerialize(users, Globals.UserPath);
        }

        public static void CurrentUserToJson(User user)

        {
            DataSerializer.JsonSerialize(user, Globals.CurrentUser); ;
        }

        public static void ExitCurrentUser()
        {
            FileStream fileStream = File.Open(Globals.CurrentUser, FileMode.Open, FileAccess.ReadWrite);
            fileStream.SetLength(0);
            fileStream.Close();
        }

        public static bool CheckUser()
        {
            FileStream fileStream = File.Open(Globals.CurrentUser, FileMode.Open, FileAccess.ReadWrite);

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
            DataSerializer.JsonSerialize(products, Globals.Products);
        }

        public static void CurrentBasketToJson(Basket basket)
        {
            DataSerializer.JsonSerialize(basket, Globals.CurrentBasket); ;
        }

        public static bool CheckBasket()
        {
            FileStream fileStream = File.Open(Globals.CurrentBasket, FileMode.Open, FileAccess.ReadWrite);

            if (fileStream.Length == 0 || fileStream.Length == 4)
            {
                fileStream.Close();

                return false;
            }

            fileStream.Close();

            return true;
        }

        public static bool CheckBaskets()
        {
            FileStream fileStream = File.Open(Globals.BasketPath, FileMode.Open, FileAccess.ReadWrite);

            if (fileStream.Length == 0)
            {
                fileStream.Close();

                return false;
            }

            fileStream.Close();

            return true;
        }

        public static void NewBasketToJson(List<Basket> baskets)
        {
            DataSerializer.JsonSerialize(baskets, Globals.BasketPath);
        }

        public static void ExitCurrentBasket()
        {
            FileStream fileStream = File.Open(Globals.CurrentBasket, FileMode.Open, FileAccess.ReadWrite);
            fileStream.SetLength(0);
            fileStream.Close();
        }
    }
}