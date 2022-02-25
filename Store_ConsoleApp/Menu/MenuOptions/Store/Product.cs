using InternshipProject.ConsoleMenu;
using Newtonsoft.Json;
using StoreConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreConsoleApp.Menu.MenuOptions.Store
{
    class Product
    {
        public static List<Product> Products = new List<Product>();
        public int Id { get; private set; }
        public string Name;
        public string Description;
        public decimal Price;
        public int Amount;
        public bool IsInBusket;

        public Product(string name, string description, decimal price, int amount, bool isInBasket)
        {
            Id++;
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
            IsInBusket = isInBasket;
        }

        public static void AddProduct()
        {
            Console.WriteLine("Enter the product name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the product description");
            var description = Console.ReadLine();
            Console.WriteLine("Enter the product price");
            var price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the product amount");
            var amount = Convert.ToInt32(Console.ReadLine());
            var product = new Product(name, description, price, amount, false);
            GetProducts();
            Products.Add(product);
            DataManagerJson.NewProductToJson(Products);
        }

        private static void GetProducts()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\ProductData.json";
            var json = File.ReadAllText(path);
            Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json).ToList();
        }

        public static void GetAndShowProducts()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\ProductData.json";
            var json = File.ReadAllText(path);
            Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json).ToList();
            foreach (var product in Products)
            {
                product.ShowProduct();
            }
        }

        public void ShowProduct()
        {
            Console.WriteLine($"| Name: {Name} | Description: {Description} | Price: {Price} | Amount: {Amount} | ");
        }
    }
}
