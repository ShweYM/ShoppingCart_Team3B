using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class Account
    {
        public string username { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
    }
}
