using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Team3B_ShoppingCart.DB;
using Team3B_ShoppingCart.Models;

namespace Team3B_ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        public ShoppingCartContext dbcontext;


        public HomeController(ShoppingCartContext dbcontext)
        {
            this.dbcontext = dbcontext;
        
        }

        public IActionResult Index()
        {
            ViewBag.page = "Home";
        
            ViewData["loginSessionId"] = HttpContext.Session.GetString("SessionId");

            Session browseSession = new BrowseSession();
            DBTester dbTester = new DBTester(dbcontext);


            if (Request.Cookies["sessionId"] is null)
            {
                StartBrowseSession(browseSession);
                return RedirectToAction("Index", "Home");
            }
            dbTester.StoreSessionId(browseSession, null, Request.Cookies["SessionId"]); //this 1 need to consider eixsting 1

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

        public IActionResult HomeViewIndex()
        {
            DBTester dbtester = new DBTester(dbcontext);
            List<Product> product = dbtester.GetProducts();
            return PartialView("_HomePartial", product);
            

        }

        public IActionResult getBasketCount()
        {
            int qtycount = 0;
            string browsesessionid = Request.Cookies["sessionId"];
            
            var cartcount = dbcontext.Carts.Where(x => x.SessionID == browsesessionid).ToList();
            if(cartcount.Count() > 0)
            {
                foreach (var qty in cartcount)
                {
                    qtycount += qty.CartQuantity;
                }
                return new JsonResult(new { success = qtycount });
            }
            else
            {
                return new JsonResult(new { success = 0 });
            }
           
        }

        public IActionResult SearchProduct(String productname = null)
        {
            DBTester dbtester = new DBTester(dbcontext);
            List<Product> product = dbtester.GetSearchProducts(productname);
            if (product.Count != 0)
            {
                return PartialView("_HomePartial", product);
            }
            else
            {
                return RedirectToAction("HomeViewIndex", "Home");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StartBrowseSession(Session browseSession)
        {
            string sessionId = Guid.NewGuid().ToString();

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Append("sessionId", sessionId, options);
            HttpContext.Session.SetString("BrowseSessionId", Guid.NewGuid().ToString());
            DBTester dbTester = new DBTester(dbcontext);

            //string sessionId = HttpContext.Session.GetString("BrowseSessionId");
            dbTester.StoreSessionId(browseSession, null, sessionId);

            return RedirectToAction("Index");
        }

        public IActionResult EndBrowseSession()
        {
            Response.Cookies.Delete("sessionId");
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }
        public Customer FindCustomer(string login)
        {
            Customer customer = dbcontext.Customers.Find(login);

            return customer;

        }
        public IActionResult AddToCart(string productID)
        {
            string browseSessionId = Request.Cookies["sessionId"];
            string loginSessionId = HttpContext.Session.GetString("SessionId");
            string isUserLogin = HttpContext.Session.GetString("username");

            Session browsesession = dbcontext.Sessions.Find(browseSessionId);
            Session loginsession = dbcontext.Sessions.Find(loginSessionId);
            Product product = dbcontext.Products.Find(productID);

            Cart cart_check = new Cart();

            cart_check = dbcontext.Carts.Where(x => x.ProductID == productID && x.SessionID == browsesession.SessionID).FirstOrDefault();
            
            if (cart_check != null)
            {
                cart_check.CartQuantity = (int)cart_check.CartQuantity + 1;
                dbcontext.Update(cart_check);
                dbcontext.SaveChanges();
            }
            else
            {
                Cart cart = new Cart()
                {
                    ProductID = product.ProductID,
                };
                if (isUserLogin != null)
                {
                    cart.CustomerID = isUserLogin;
                }
                cart.SessionID = browseSessionId;
                cart.CartQuantity = 1;
                dbcontext.Add(cart);
                dbcontext.SaveChanges();
            }

            return Content("This is a GET result, your productId is " + productID);
        }
    }
}
