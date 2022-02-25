using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Console_store.Menu.Enums
{
    public static class MenuItem
    {
        public enum MenuItems
        {
            [Description("Store")]
            Store = 1,
            [Description("Basket")]
            Basket,
            [Description("Profile")]
            Profile,
            [Description("Login")]
            Login,
            [Description("CreateNewUser")]
            CreateNewUser,
            [Description("Exit")]
            Exit
        }

        public static string GetDescription(this Enum genericEnum)
        {
            var genericEnumType = genericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(genericEnum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attribs != null && attribs.Count() > 0)
                {
                    return ((DescriptionAttribute)attribs.ElementAt(0)).Description;
                }
            }

            return genericEnum.ToString();
        }
    }
}
