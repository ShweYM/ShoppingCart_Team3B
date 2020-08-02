using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team3B_ShoppingCart.DB;
using Team3B_ShoppingCart.Models;

namespace Team3B_ShoppingCart.Controllers
{
    public class BasketController : Controller
    {
        public ShoppingCartContext dbcontext;

        public BasketController(ShoppingCartContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            ViewBag.page = "Basket";
            ViewData["loginSessionId"] = HttpContext.Session.GetString("SessionId");

            if (HttpContext.Session.GetString("username") != null) //used to transfer viewbag data back to view
            {
                Customer customer1 = FindCustomer(HttpContext.Session.GetString("username"));
                ViewData["CustomerName"] = customer1.FirstName + " " + customer1.LastName;
                ViewBag.CustomerName = ViewData["CustomerName"].ToString();
                ViewData["CustomerID"] = customer1.CustomerID;
                ViewBag.CustomerID = ViewData["CustomerID"].ToString();
                Debug.WriteLine("This is definitely something" + (string)ViewBag.CustomerName); //Used to check does the code run to this location
            }

            return View();
        }

        public Customer FindCustomer(string login)
        {
            Customer customer = dbcontext.Customers.Find(login);

            return customer;

        }

        public IActionResult BasketIndex()
        {
            string login_check = HttpContext.Session.GetString("username");
            Debug.WriteLine("The login_check is " + login_check);
            string browsesession = Request.Cookies["sessionId"];
            Debug.WriteLine("The browsesession " + browsesession);

            DBTester dbtester = new DBTester(dbcontext);

            List<CheckoutCart> cartresultbyID = new List<CheckoutCart>();

            if (login_check != null)
            {
                cartresultbyID = dbtester.ManageDataFromCartCID(login_check);
            }
            else
            {
                cartresultbyID = dbtester.ManageDataFromCartBSI(browsesession);

            }
            if (cartresultbyID != null)
            {
                return PartialView("_BasketPartial",cartresultbyID);
            }
            return null;
        }

        public IActionResult ReduceItem(string productID)
        {
            string sessionId = Request.Cookies["sessionId"];
            Session session = dbcontext.Sessions.Find(sessionId);
            Product product = dbcontext.Products.Find(productID);
            Cart cart_check = dbcontext.Carts.Where(x => x.ProductID == productID && x.SessionID == session.SessionID).FirstOrDefault();

            if (cart_check.CartQuantity > 1)
            {
                cart_check.CartQuantity = (int)cart_check.CartQuantity - 1;
                dbcontext.Update(cart_check);
                dbcontext.SaveChanges();
            }
            else
            {
                dbcontext.Remove(cart_check);
                dbcontext.SaveChanges();
            }
            return new JsonResult(new { success = "Success"});
        }

        public IActionResult AddItem(string productID)
        {
            string sessionId = Request.Cookies["sessionId"];
            Session session = dbcontext.Sessions.Find(sessionId);
            Product product = dbcontext.Products.Find(productID);
            Cart cart_check = dbcontext.Carts.Where(x => x.ProductID == productID && x.SessionID == session.SessionID).FirstOrDefault();

            if (cart_check != null)
            {
                cart_check.CartQuantity = (int)cart_check.CartQuantity + 1;
                dbcontext.Update(cart_check);
                dbcontext.SaveChanges();
            }
            return new JsonResult(new { success = "Success" });
        }

        

        public IActionResult Remove(string productID)
        {
            string sessionId = Request.Cookies["sessionId"];
            Session session = dbcontext.Sessions.Find(sessionId);
            Product product = dbcontext.Products.Find(productID);
            Cart cart_check = dbcontext.Carts.Where(x => x.ProductID == productID && x.SessionID == session.SessionID).FirstOrDefault();

            if (cart_check != null)
            {
                dbcontext.Remove(cart_check);
                dbcontext.SaveChanges();
            }
           
            return new JsonResult(new { success = "Success" });
        }

        public IActionResult GetDataFromCart()
        {
            ViewData["loginSessionId"] = HttpContext.Session.GetString("SessionId");
            
            if (HttpContext.Session.GetString("username") != null)
            {
                string session = Request.Cookies["SessionId"];
                DBTester dbtester = new DBTester(dbcontext);
                String result = dbtester.GetDataFromCart(HttpContext.Session.GetString("username"), session);
                return new JsonResult(new { success = "Success" });
            }
            else
            {
                return new JsonResult(new { success = "NotLogin" });
            }



        }




    }
}