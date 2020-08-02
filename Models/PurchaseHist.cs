using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class PurchaseHist
    {
        public string imageurl { get; set; }
        public string productname { get; set; }
        public DateTime purchasedate { get; set; }
        public double price { get; set; }
        public int orderid { get; set; }
        public int salesquantity { get; set; }
        public string  activationcode { get; set; }
        public string description { get; set; }
    }
}
