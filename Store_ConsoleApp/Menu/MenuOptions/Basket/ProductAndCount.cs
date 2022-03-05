using System;

namespace StoreConsoleApp.Menu.MenuOptions.Basket
{
    internal class ProductAndCount
    {
        public Guid Item;
        private int count;

        public int Count
        {
            set
            {
                if (value < 1)
                {
                    throw new Exception("Count of the product can not be less then zero");
                }
                else
                {
                    count = value;
                }
            }
            get { return count;}
        }
    }
}