using Newtonsoft.Json;
using StoreConsoleApp.Data;
using StoreConsoleApp.Menu;
using StoreConsoleApp.Menu.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StoreConsoleApp.MenuOptions
{
    public class User
    {
        public static List<User> Users = new List<User>();
        public Guid Instanceid { get; set; }
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
            String encPassword = Validation.Encryption(password, "password");
            Console.WriteLine("Enter your email");
            var email = Console.ReadLine();
            if (Validation.IsValidEmail(email))
            {
                if (GetUser().IsAdmin)
                {
                    Console.WriteLine("Choose a role " + "\n 1 - User" + "\n 2 - Admin");
                    var role = Convert.ToInt32(Console.ReadLine());

                    if (role == 2)
                    {
                        isAdmin = true;
                    }
                }
                else
                {
                    isAdmin = false;
                }
                User user = new(login, encPassword, email, isAdmin);
                GetUsers();
                Users.Add(user);
                Console.WriteLine($"Welcome: {user.Login}");
                DataManagerJson.ExitCurrentUser();
                DataManagerJson.ExitCurrentBasket();
                DataManagerJson.NewUserToJson(Users);
                DataManagerJson.CurrentUserToJson(user);
            }
        }

        public static void LoginUser()
        {
            GetUsers();
            Console.WriteLine("Enter your login");
            var login = Console.ReadLine();
            string enterText = "Please enter password: ";
            var enterPassword = Validation.CheckPassword(enterText);
            var CurrentUser = Users.Find((user) => user.Login == login);

            if (login == string.Empty || enterPassword == string.Empty)
            {
                throw new Exception("Enter the values");
            }

            if (CurrentUser == null)
            {
                throw new Exception("User with this data was not found");
            }
            String currentPassword = Validation.Decryption(CurrentUser.Password, "password");
            if (currentPassword == enterPassword)
            {
                DataManagerJson.ExitCurrentUser();
                DataManagerJson.ExitCurrentBasket();
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
            var json = File.ReadAllText(Globals.UserPath);
            Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
        }

        public static void GetAndShowUsers()
        {
            var json = File.ReadAllText(Globals.UserPath);
            Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
            var indexOfChoice = 0;

            foreach (var user in Users)
            {
                user.ShowUser(++indexOfChoice);
            }
        }

        public static User GetUser()
        {
            var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
            return user;
        }

        public static void DeleteUser()
        {
            try
            {
                GetUsers();
                Console.WriteLine("Enter the user number");
                var userIndex = Convert.ToInt32(Console.ReadLine());
                Users.RemoveAt(userIndex - 1);
                DataManagerJson.NewUserToJson(Users);
                Console.WriteLine("User removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool CheckIsUserAdmin()
        {
            var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;

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

        public void ShowUser(int index)
        {
            Console.WriteLine($"{index}) Login: {Login}, Password {Password}, Email: {Email}, IsAdmin: {IsAdmin}");
        }
    }
}