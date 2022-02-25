using System;
using InternshipProject.ConsoleMenu;
using Newtonsoft.Json;
using StoreConsoleApp.Menu;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StoreConsoleApp.Data;
using Store_ConsoleApp.Menu;

namespace StoreConsoleApp.MenuOptions
{
    public class User
    {
        public static List<User> Users = new List<User>();
        public Guid Instanceid { get; private set; }
        public string Login;
        public string Password;
        public string Email;
        public bool IsAdmin;

        public User(string login, string password, string email, bool isAdmin)
        {
            Instanceid = Guid.NewGuid();
            Login = login;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
        }

        public static void UserRegistration()
        {
            bool isAdmin = false;
            Console.WriteLine("Enter your login");
            var login = Console.ReadLine();
            Console.WriteLine("Enter you password");
            var password = Console.ReadLine();
            Console.WriteLine("Enter your email");
            var email = Console.ReadLine();
            Console.WriteLine("Choose a role " + "\n 1 - User" + "\n 2 - Admin");
            var role = Convert.ToInt32(Console.ReadLine());

            if (role == 2)
            {
                isAdmin = true;
            }

            User user = new(login, password, email, isAdmin);
            GetUsers();
            Users.Add(user);
            DataManagerJson.NewUserToJson(Users);
            DataManagerJson.CurrentUserToJson(user);
        }

        public static void LoginUser()
        {
            GetUsers();
            Console.WriteLine("Enter your login");
            var login = Console.ReadLine();
            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();
            var CurrentUser = Users.Find((user) => user.Login == login);

            if (login == string.Empty || password == string.Empty)
            {
                throw new Exception("Enter the values");
            }

            if (CurrentUser == null)
            {
                throw new Exception("User with this data was not found");
            }

            if (CurrentUser.Password == password)
            {
                Console.WriteLine("You are authorized");
                DataManagerJson.CurrentUserToJson(CurrentUser);
                var menu = new ConsoleMenu();
                menu.ShowMenu();
            }
            else
            {
                throw new Exception("User with this data was not found");
            }
        }

        public static void GetUsers()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\UserData.json";
            var json = File.ReadAllText(path);
            Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
        }

        public static void GetAndShowUsers()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\UserData.json";
            var json = File.ReadAllText(path);
            Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
            foreach (var user in Users)
            {
                user.ShowUser();
            }
        }

        public static User GetUser()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\CurrentUser.json";
            var user = DataSerializer.JsonDeserialize(typeof(User), path) as User;
            return user;
        }
        public static bool CheckIsUserAdmin()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\CurrentUser.json";
            var user = DataSerializer.JsonDeserialize(typeof(User), path) as User;
            if (user.IsAdmin)
            {
                Console.WriteLine("Hi, Admin! You can see administrator menu below");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowUser()
        {
            Console.WriteLine($"Login: {Login}, Password {Password}, Email: {Email}, IsAdmin: {IsAdmin}");
        }
    }
}
