using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreConsoleApp.Enums
{
    public static class AdminMenus
    {
        public enum AdminMenu
        {
            [Description("Show Products")]
            ShowProduct = 1,
            [Description("Add Product")]
            AddProduct,
            [Description("Delete Product")]
            DeleteProduct,
            [Description("Change Product price")]
            ChangeProductPrice,
            [Description("Show Users")]
            ShowUsers,
            [Description("CreateNewUser")]
            CreateNewUser,
            [Description("DeleteUser")]
            DeleteUser,
            [Description("Exit")]
            Exit
        }
    }
}
