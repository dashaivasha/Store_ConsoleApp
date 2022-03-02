using System;
using System.IO;

namespace StoreConsoleApp
{
    static class Globals
    {
        private static string _workingDirectory = Environment.CurrentDirectory;
        private static string _projectDirectory = Directory.GetParent(_workingDirectory).Parent.Parent.FullName;
        public static string UserPath = $"{_projectDirectory}\\Data\\UserData.json";
        public static string CurrentUser = $"{_projectDirectory}\\Data\\CurrentUser.json";
        public static string CurrentBasket = $"{_projectDirectory}\\Data\\CurrentBasket.json";
        public static string BasketPath = $"{_projectDirectory}\\Data\\Baskets.json";
        public static string Products = $"{_projectDirectory}\\Data\\ProductData.json";
    }
}
