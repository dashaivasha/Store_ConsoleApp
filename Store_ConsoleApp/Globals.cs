using System;
using System.IO;

namespace StoreConsoleApp
{
    static class Globals
    {
        private static string _workingDirectory = Environment.CurrentDirectory;

        public static string ProjectDirectory = Directory.GetParent(_workingDirectory).Parent.Parent.FullName;
    }
}
