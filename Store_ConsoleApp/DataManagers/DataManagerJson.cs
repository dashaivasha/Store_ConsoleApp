using System;
using InternshipProject.ConsoleMenu;
using System.Collections.Generic;
using System.IO;

namespace Store_ConsoleApp.Data
{
    internal class DataManagerJson
    {
        private static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public static void NewUserToJson(List<User> users)
        {
            var path = $"{projectDirectory}\\Data\\Userdata.json";
            DataSerializer.JsonSerialize(users, path);
        }

        public static void CurrentUserToJson(User user)
        {
            var path = $"{projectDirectory}\\Data\\CurrentUser.json";
            DataSerializer.JsonSerialize(user, path);
        }

        public static void ExitCurrentUser()
        {
            var path = $"{projectDirectory}\\Data\\CurrentUser.json";
            FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            fileStream.SetLength(0);
            fileStream.Close();
        }

        public static bool CheckUser()
        {
            var path = $"{projectDirectory}\\Data\\CurrentUser.json";
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
    }
}