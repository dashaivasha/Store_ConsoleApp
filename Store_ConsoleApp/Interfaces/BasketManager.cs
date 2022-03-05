using System;

namespace StoreConsoleApp.Interfaces
{
    abstract class BasketManager
    {
        public static void GetBaskets() {}
        public static void FindUserBasket() {}
        public static void CreateBasket(Guid CurrentProduct) {}
        public static void AddingProductToBasket() {}
        public static void DeleteBasket() {}
        public static void FinalCost() {}
        public static void ChangeProductCount() {}
        public static void DeleteProductFromBasket() {}
    }
}
