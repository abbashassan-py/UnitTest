using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_task.Data
{
    public class CreateAnAccountData
    {
        public static object[] TestDataForAccount =
        {
            new object[]
            {
                $"HaiderHassan{DateTime.Now.ToString("MM/dd/yyy hh:mm tt").Replace(" ", "").Replace("/", "").Replace(":", "")}@conntour-sofware.com",
                "Mr.",
                "abbas",
                "hassan",
                "Password1",
                7,
                "July",
                2022,
                "Sign up for our newsletter!",
                "Company",
                "Address1",
                "Address2",
                "City1",
                "Alabama",
                35004,
                "Additional Info",
                452778,
                911345329,
                "Allias 1"
            }
        };


        public static object[] TestDataForAccount_1 =
        {
            new object[]
            {
                $"HaiderHassan{DateTime.Now.ToString("MM/dd/yyy hh:mm tt").Replace(" ", "").Replace("/", "").Replace(":", "")}@conntour-sofware.com",
                "Mrs.",
                "Haider",
                "hassan",
                "Password2",
                7,
                "July",
                2021,
                "Sign up for our newsletter!",
                "Company",
                "Address11",
                "Address22",
                "City1",
                "Alabama",
                35004,
                "Additional Info",
                452778,
                911345329,
                "Allias 6"
            }
        };

    }
}

