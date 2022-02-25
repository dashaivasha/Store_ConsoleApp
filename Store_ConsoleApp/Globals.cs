using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreConsoleApp
{
    static class Globals
    {
        private static string _workingDirectory = Environment.CurrentDirectory;

        public static string ProjectDirectory = Directory.GetParent(_workingDirectory).Parent.Parent.FullName;
    }
}
