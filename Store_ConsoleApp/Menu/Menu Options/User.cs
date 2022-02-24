using System;
using InternshipProject.ConsoleMenu;
using Newtonsoft.Json;
using Store_ConsoleApp.Menu;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Store_ConsoleApp.Data
{
    public class User
    {
        private static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public static List<User> Users = new List<User>();
        public Guid InstanceID { get; private set; }
        public string Login;
        public string Password;
        public string Email;
        public bool IsAdmin;

        public User(string login, string password, string email, bool isAdmin)
        {
            this.InstanceID = Guid.NewGuid();
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.IsAdmin = isAdmin;
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
            var current_user = Users.Find((user) => user.Login == login);

            if (login == string.Empty || password == string.Empty)
            {
                throw new Exception("Enter the values");
            }

            if (current_user == null)
            {
                throw new Exception("User with this data was not found");
            }
            if (current_user.Password == password)
            {
                Console.WriteLine("You are authorized");
                DataManagerJson.CurrentUserToJson(current_user);
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
            var path = $"{projectDirectory}\\Data\\Userdata.json";
            var json = File.ReadAllText(path);
            Users = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
            //foreach (var user in Users)
            //{
            //   user.ShowUser();
            //}
        }

        public static User GetUser()
        {
            var path = $"{projectDirectory}\\Data\\CurrentUser.json";
            var user = DataSerializer.JsonDeserialize(typeof(User), path) as User;
            return user;
        }

        public void ShowUser()
        {
            Console.WriteLine($"Login: {Login}, Password {Password}, Email: {Email}, IsAdmin: {IsAdmin}");
        }
    }
}