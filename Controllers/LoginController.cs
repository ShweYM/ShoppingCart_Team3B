using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team3B_ShoppingCart.DB;
using Team3B_ShoppingCart.Models;


namespace Team3B_ShoppingCart.Controllers
{
    //kKCOMMENT
    public class LoginController : Controller
    {
        protected ShoppingCartContext dbcontext;

        public LoginController(ShoppingCartContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IActionResult Account(string login, string password)
        {
            Customer customer = dbcontext.Customers.Where(x => x.CustomerID == login).FirstOrDefault();

            return View(customer);
        }

        public IActionResult UpdatePassword(string email,string oldpassword, string newpassword)
        {
            string username = HttpContext.Session.GetString("username");
            var key = "E546C8DF278CD5931069B522E695D4F2";
            Customer customer = dbcontext.Customers.Where(x => x.EmailAddress == email && x.Password == Utils.Crypto.Encrypt(oldpassword, key)).FirstOrDefault();
         //   var oldpasswordfromdb = Utils.Crypto.Decrypt(customer.Password,key);

            if(customer != null)
            {
                customer.Password = Utils.Crypto.Encrypt(newpassword,key);
                dbcontext.Update(customer);
                dbcontext.SaveChanges();
                Response.Cookies.Delete(".AspNetCore.Session");
                return new JsonResult(new { success = "Success" });
            }
            return new JsonResult(new { success = "Fail" });
        }
        public IActionResult Index(string login, string password,string cmd)
        {
            ViewData["loginSessionId"] = HttpContext.Session.GetString("SessionId");

            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(login))
            {
                ViewBag.viewcart = cmd;
                return View();
            }

            SearchUsername(login, password, cmd);

            ViewData["loginSessionId"]= HttpContext.Session.GetString("SessionId");
            Customer customer = FindCustomer(login);
            //bool query = Request.Query.ContainsKey("cmd");
            //bool query_string = Request.QueryString.HasValue;
            //if (query_string is true)
            //{
            //    return RedirectToAction("Index", "Basket");
            //}

            if(cmd == "viewcart")
            {
                return RedirectToAction("Index", "Basket");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }


        public IActionResult SearchUsername(string login, string password,string? cmd)
        {

            Customer customer = dbcontext.Customers.Find(login);
            Session loginSession = new LoginSession();
            //  var password = Utils.Crypto.Sha256(

            var key = "E546C8DF278CD5931069B522E695D4F2";//Since GUID space //

            var decrypted = Utils.Crypto.Decrypt(customer.Password, key);

            //var decrypted = Utils.Crypto.Decrypt(customer.Password, key);

            if (customer != null)
            {
                if (decrypted == password)
                {
                    HttpContext.Session.SetString("username", login);
                    Debug.WriteLine("Login is " + login);
                    HttpContext.Session.SetString("SessionId", Guid.NewGuid().ToString());
                    DBTester dbTester = new DBTester(dbcontext);

                    string sessionId = HttpContext.Session.GetString("SessionId");
                    string username = HttpContext.Session.GetString("username");

                    dbTester.StoreSessionId(loginSession, username, sessionId);
                    ViewData["loginSessionId"] = HttpContext.Session.GetString("SessionId");
                    ViewData["CustomerName"] = customer.FirstName + " " + customer.LastName;
                    ViewBag.CustomerName = ViewData["CustomerName"].ToString();
                    ViewData["CustomerID"] = login;
                    Debug.WriteLine((string)ViewBag.CustomerName);

                    Session browseSession = dbcontext.Sessions
                        .Where(x => x.SessionID == Request.Cookies["sessionID"]).FirstOrDefault();

                    List<Cart> carts = dbcontext.Carts
                        .Where(x => x.SessionID == browseSession.SessionID).ToList();

                    foreach (Cart cart in carts)
                    {
                        cart.CustomerID = login;
                        dbcontext.Update(cart);
                        dbcontext.SaveChanges();
                    }
                    

                    return RedirectToAction("Index", "Home");
                }
            }
            Debug.WriteLine("This SearchUsername function didnt work");

            return RedirectToAction("Index", "Login");

        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction("Index", "Home");
        }

        public Customer FindCustomer(string login)
        {
            Customer customer = dbcontext.Customers.Find(login);

            return customer;

        }

    }
}