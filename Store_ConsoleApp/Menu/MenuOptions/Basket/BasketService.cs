using System;
using Newtonsoft.Json;
using StoreConsoleApp.Data;
using StoreConsoleApp.Exceptions;
using StoreConsoleApp.Menu.MenuOptions.Store;
using StoreConsoleApp.MenuOptions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StoreConsoleApp.Interfaces;

namespace StoreConsoleApp.Menu.MenuOptions.Basket
{
    internal class BasketService : BasketManager
    {
        public static List<Basket> Baskets = new List<Basket>();
        public static Basket CurrentBasket = new Basket();
        public static List<Product> currentBasketProducts = new List<Product>();

        public static new void GetBaskets()
        {
            if (DataManagerJson.CheckBaskets())
            {
                var json = File.ReadAllText(Globals.BasketPath);
                Baskets = JsonConvert.DeserializeObject<IEnumerable<Basket>>(json).ToList();
            }
            else
            {
                Console.WriteLine("No one basket in the base");
            }
        }

        public static new void FindUserBasket()
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
                    Console.WriteLine("Basket is empty");
                }
            }
        }

        public static new void CreateBasket(Guid CurrentProduct)
        {
            var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
            var productAndCount = new ProductAndCount();
            CurrentBasket.ProductsInBasket.Clear();
            productAndCount.Item = CurrentProduct;
            Console.WriteLine("Enter count of the product");
            int count = Convert.ToInt32(Console.ReadLine());

            productAndCount.Count = count;
            CurrentBasket.ProductsInBasket.Add(productAndCount);
            CurrentBasket.UserId = user.Instanceid;
            Baskets.Add(CurrentBasket);
            DataManagerJson.CurrentBasketToJson(CurrentBasket);
            DataManagerJson.NewBasketToJson(Baskets);
        }

        public static new void AddingProductToBasket()
        {
            GetBaskets();
            Product.GetProducts();
            var user = DataSerializer.JsonDeserialize(typeof(User), Globals.CurrentUser) as User;
            Console.WriteLine("Enter the product number");
            var productIndex = Convert.ToInt32(Console.ReadLine());
            var CurrentProduct = Product.Products[productIndex - 1].InstanceId;

            if (DataManagerJson.CheckBasket() == false && IsThisBasketExist() == false)
            {
                CreateBasket(CurrentProduct);
            }

            else if (DataManagerJson.CheckBasket() == true && IsThisBasketExist() == true || DataManagerJson.CheckBasket() == false && IsThisBasketExist() == true)
            {
                var currentBasket = Baskets.Find((basket) => basket.UserId == user.Instanceid);
                var productAndCount = new ProductAndCount();
                int count;

                if (IsThisProductExist(CurrentProduct))
                {
                    var item = currentBasket.ProductsInBasket.Find((item) => item.Item == CurrentProduct);
                    count = ++item.Count;
                    currentBasket.ProductsInBasket.Remove(item);
                }
                else
                {
                    Console.WriteLine("Enter count of the product");
                    count = Convert.ToInt32(Console.ReadLine());
                }

                productAndCount.Count = count;
                productAndCount.Item = CurrentProduct;
                currentBasket.ProductsInBasket.Add(productAndCount);
                currentBasket.UserId = user.Instanceid;
                DataManagerJson.CurrentBasketToJson(currentBasket);
                DeleteBasket();
                Baskets.Add(currentBasket);
                DataManagerJson.NewBasketToJson(Baskets);
            }
        }

        public static new void DeleteBasket()
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
                var currentProduct = Product.Products.Find((product) => product.InstanceId == productId.Item);
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

        public static bool IsThisProductExist(Guid itemToBeAdded)
        {
            var basket = DataSerializer.JsonDeserialize(typeof(Basket), Globals.CurrentBasket) as Basket;
            var productCheck = basket.ProductsInBasket.Find((product) => product.Item == itemToBeAdded);

            if (productCheck == null)
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
            var basket = DataSerializer.JsonDeserialize(typeof(Basket), Globals.CurrentBasket) as Basket;
            var index = 0;

            foreach (var product in currentBasketProducts)
            {
                var counts = basket.ProductsInBasket.Find((productForGetCount) => productForGetCount.Item == product.InstanceId);
                product.ShowProductInBasket(++index, counts.Count);
            }

            FinalCost();
        }

        public static new void FinalCost()
        {
            GetCurrentProductsListInBasket();
            var basket = DataSerializer.JsonDeserialize(typeof(Basket), Globals.CurrentBasket) as Basket;
            decimal sum = 0;

            for (var i = 0; i < currentBasketProducts.Count(); i++)
            {
                var counts = basket.ProductsInBasket.Find((productForGetCount) => productForGetCount.Item == currentBasketProducts[i].InstanceId);
                sum = sum + currentBasketProducts[i].Price * counts.Count;
            }

            Console.WriteLine($"Final cost: " + sum);
        }

        public static new void DeleteProductFromBasket()
        {
            try
            {
                var basket = DataSerializer.JsonDeserialize(typeof(Basket), Globals.CurrentBasket) as Basket;
                Console.WriteLine("Enter the product number");
                var productIndex = Convert.ToInt32(Console.ReadLine());
                var CurrentProduct = currentBasketProducts[productIndex - 1].InstanceId;
                var item = basket.ProductsInBasket.Find((item) => item.Item == CurrentProduct);
                basket.ProductsInBasket.Remove(item);
                DataManagerJson.CurrentBasketToJson(basket);
                DeleteBasket();
                Baskets.Add(basket);
                DataManagerJson.NewBasketToJson(Baskets);
                Console.WriteLine("product removed");
            }
            catch (BasketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static new void ChangeProductCount()
        {
            try
            {
                var basket = DataSerializer.JsonDeserialize(typeof(Basket), Globals.CurrentBasket) as Basket;
                Console.WriteLine("Enter the product number");
                var productIndex = Convert.ToInt32(Console.ReadLine());
                var CurrentProduct = currentBasketProducts[productIndex - 1].InstanceId;
                var item = basket.ProductsInBasket.Find((item) => item.Item == CurrentProduct);
                Console.WriteLine("Enter new product count");
                var newCount = Convert.ToInt32(Console.ReadLine());
                item.Count = newCount;
                DataManagerJson.CurrentBasketToJson(basket);
                DeleteBasket();
                Baskets.Add(basket);
                DataManagerJson.NewBasketToJson(Baskets);
                Console.WriteLine("count changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
