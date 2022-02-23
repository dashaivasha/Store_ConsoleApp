using InternshipProject.ConsoleMenu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_ConsoleApp.Data
{
    class DataManagerJson
    {
        public static void NewUserToJson(List<User> users)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var path = $"{projectDirectory}\\Data\\Userdata.json";
            DataSerializer.JsonSerialize(users, path);
        }
    }
}