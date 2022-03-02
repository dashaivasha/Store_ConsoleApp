using System;
using System.Collections.Generic;

namespace StoreConsoleApp.Menu.MenuOptions.Basket
{
    internal class Basket
    {
        public Guid BasketId { get; set; }
        public Guid UserId;
        public List<Guid> ProductsInBasket;

        public Basket(Guid basketId, Guid userId, List<Guid> products)
        {
            BasketId = basketId;
            UserId = userId;
            ProductsInBasket = products;
        }

        public Basket()
        {
            BasketId = Guid.NewGuid();
            ProductsInBasket = new List<Guid>();
        }
    }
}