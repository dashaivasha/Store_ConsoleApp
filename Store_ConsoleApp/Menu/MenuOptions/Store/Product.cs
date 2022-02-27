using Newtonsoft.Json;
using StoreConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StoreConsoleApp.Menu.MenuOptions.Store
{
    internal class Product
    {
        public static List<Product> Products = new List<Product>();
        public Guid Instanceid { get; private set; }
        public string Name;
        public string Description;
        public decimal Price;
        public int Amount;
        public bool IsInBusket;

        public Product(string name, string description, decimal price, int amount, bool isInBasket)
        {
            Instanceid = Guid.NewGuid();
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
            Console.WriteLine("Enter the product price (using ',' for decimal value)");
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

        public static void DeleteProduct()
        {
            try
            {
                GetProducts();
                Console.WriteLine("Enter the product number");
                var productIndex = Convert.ToInt32(Console.ReadLine());
                Products.RemoveAt(productIndex - 1);
                DataManagerJson.NewProductToJson(Products);
                Console.WriteLine("Poduct removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ChangeProduct()
        {
            try
            {
                GetProducts();
                Console.WriteLine("Enter the product id");
                var productIndex = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new product price");
                var newPrice = Convert.ToDecimal(Console.ReadLine());
                var CurrentProduct = Products[productIndex - 1];
                CurrentProduct.Price = newPrice;
                DataManagerJson.NewProductToJson(Products);
                Console.WriteLine("Price changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetAndShowProducts()
        {
            var path = $"{Globals.ProjectDirectory}\\Data\\ProductData.json";
            var json = File.ReadAllText(path);
            Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json).ToList();
            var indexOfChoice = 0;

            foreach (var product in Products)
            {
                product.ShowProduct(++indexOfChoice);
            }
        }

        public void ShowProduct(int indexOfChoice)
        {
            Console.WriteLine($"{indexOfChoice}) | Name: {Name} | Description: {Description} | Price: {Price} | Amount: {Amount} | ");
        }
    }
}