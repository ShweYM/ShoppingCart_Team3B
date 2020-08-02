using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team3B_ShoppingCart.DB;

namespace Team3B_ShoppingCart.Controllers
{
    public class CheckoutController : Controller
    {

        public ShoppingCartContext dbcontext;

        public CheckoutController(ShoppingCartContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }
        public IActionResult Index()
        {
           
            return View();

        }

    }
}