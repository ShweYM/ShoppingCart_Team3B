using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team3B_ShoppingCart.DB;
using Team3B_ShoppingCart.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team3B_ShoppingCart.Controllers
{
    public class ProductDetailController : Controller
    {

        public ShoppingCartContext dbcontext;


        public ProductDetailController(ShoppingCartContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }
        // GET: /ProductDetail/
        public IActionResult Index(string id)
        {
            string sessionID = Request.Cookies["sessionId"];
            DBTester dbtester = new DBTester(dbcontext);
            Product product = dbtester.GetProductByID(id);
            ViewBag.CartNumber = dbtester.GetBasketNumberBySessionID(sessionID);
            return View(product);
        }

        public JsonResult updateBasketNum()
        {
            string sessionID = Request.Cookies["sessionId"];
            DBTester dbtester = new DBTester(dbcontext);
            ViewBag.CartNumber = dbtester.GetBasketNumberBySessionID(sessionID);
            return Json(new {success = true, display=ViewBag.CartNumber});
        }



        //public string Index(Product item)
        //{
        //    return item.ToString();
        //    //return View(item);
        //}
    }
}
