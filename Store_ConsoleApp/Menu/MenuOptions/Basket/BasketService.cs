using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StoreConsoleApp.Data;
using StoreConsoleApp.Menu.MenuOptions.Store;
using StoreConsoleApp.MenuOptions;


namespace StoreConsoleApp.Menu.MenuOptions.Basket
{
    internal class BasketService
    {
        public static List<Basket> Baskets = new List<Basket>();
        public static Basket CurrentBasket = new Basket();
        public static List<Product> currentBasketProducts = new List<Product>();

        public static void GetBaskets()
        {
            if (DataManagerJson.CheckBaskets())
            {
                var json = File.ReadAllText(Globals.BasketPath);
                Baskets = JsonConvert.DeserializeObject<IEnumerable<Basket>>(json).ToList();
            }
            else
            {
                Console.WriteLine("No items in the basket, you can add them in the Store");
            }
        }

        public static void FindUserBasket()
        {
            if (DataManagerJson.CheckBasket())
            {
                GetCurrentProductsListInBasketAndShow();
                var basket = DataSerializer.JsonDeserialize(typeof(Basket), Globals.CurrentBasket) as Basket;
            }
            else
            {
                if (IsThisBasketExist())
                {
                    GetBaskets();
                    User.GetUsers();
                    var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
                    var currentBasket = Baskets.Find((basket) => basket.UserId == user.Instanceid);
                    DataManagerJson.CurrentBasketToJson(currentBasket);
                    GetCurrentProductsListInBasketAndShow();
                }
                else
                {
                    Console.WriteLine("No items in the basket, go to Store");
                }
            }
        }

        public static void CreateBasket(int index)
        {
            var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
            var CurrentProduct = Product.Products[index - 1].InstanceId;
            CurrentBasket.ProductsInBasket.Clear();
            CurrentBasket.ProductsInBasket.Add(CurrentProduct);
            CurrentBasket.UserId = user.Instanceid;
            Baskets.Add(CurrentBasket);
            DataManagerJson.CurrentBasketToJson(CurrentBasket);
            DataManagerJson.NewBasketToJson(Baskets);
        }

        public static void AddingProductToBasket()
        {
            GetBaskets();
            Product.GetProducts();
            var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
            Console.WriteLine("Enter the product number");
            var productIndex = Convert.ToInt32(Console.ReadLine());
            var CurrentProduct = Product.Products[productIndex - 1].InstanceId;

            if (DataManagerJson.CheckBasket() == false && IsThisBasketExist() == false)
            {
                CreateBasket(productIndex);
            }
            else if (DataManagerJson.CheckBasket() == true && IsThisBasketExist() == true || DataManagerJson.CheckBasket() == false && IsThisBasketExist() == true)
            {
                var currentBasket = Baskets.Find((basket) => basket.UserId == user.Instanceid);
                currentBasket.ProductsInBasket.Add(CurrentProduct);
                currentBasket.UserId = user.Instanceid;
                DataManagerJson.CurrentBasketToJson(currentBasket);
                DeleteBasket();
                Baskets.Add(currentBasket);
                DataManagerJson.NewBasketToJson(Baskets);
            }
        }

        public static void DeleteBasket()
        {
            try
            {
                GetBaskets();
                var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
                var basketCheck = Baskets.Find((basket) => basket.UserId == user.Instanceid);
                Baskets.Remove(basketCheck);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetCurrentProductsListInBasket()
        {
            var basket = DataSerializer.JsonDeserialize(typeof(Basket), Globals.CurrentBasket) as Basket;
            Product.GetProducts();
            List<Product> products = new List<Product>();

            foreach (var productId in basket.ProductsInBasket)
            {
                var currentProduct = Product.Products.Find((product) => product.InstanceId == productId);
                products.Add(currentProduct);
            }

            currentBasketProducts = products;
        }

        public static bool IsThisBasketExist()
        {
            GetBaskets();
            var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
            var basketCheck = Baskets.Find((basket) => basket.UserId == user.Instanceid);

            if (basketCheck == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void GetCurrentProductsListInBasketAndShow()
        {
            GetCurrentProductsListInBasket();
            var index = 0;

            foreach (var product in currentBasketProducts)
            {
                product.ShowProductInBasket(++index);
            }
        }
    }
}