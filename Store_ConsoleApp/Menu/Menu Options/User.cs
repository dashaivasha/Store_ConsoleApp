using InternshipProject.ConsoleMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store_ConsoleApp.Data
{
    public class User
    {
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
        }

        public static void GetUsers()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var path = $"{projectDirectory}\\Data\\Userdata.json";
            Users = DataSerializer.JsonDeserialize(typeof(List<User>), path) as List<User>;
            foreach (var user in Users)
            {
               user.ShowUser();
            }
        }

        public void ShowUser()
        {
            Console.WriteLine($"Login: {Login}, Password {Password}, Email: {Email}, IsAdmin: {IsAdmin}");
        }
    }
}
