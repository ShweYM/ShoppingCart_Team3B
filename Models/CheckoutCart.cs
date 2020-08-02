using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team3B_ShoppingCart.Models
{
    public class CheckoutCart
    {
        //public Cart Cart { get; set; }

        //public Product Product { get; set; }

        public string Image { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQty { get; set; }
    }
}
