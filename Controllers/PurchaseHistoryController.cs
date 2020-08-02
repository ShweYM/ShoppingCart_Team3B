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
    public class PurchaseHistoryController : Controller
    {
        public ShoppingCartContext dbcontext;

            public PurchaseHistoryController(ShoppingCartContext dbcontext)
            {
                this.dbcontext = dbcontext;

            }
        public ActionResult PurchaseHistory()
        {
            ViewBag.page = "PurchaseHistory";
            ViewData["loginSessionId"] = HttpContext.Session.GetString("SessionId");

            if (HttpContext.Session.GetString("username") != null) //used to transfer viewbag data back to view
            {
                Customer customer1 = FindCustomer(HttpContext.Session.GetString("username"));
                ViewData["CustomerName"] = customer1.FirstName + " " + customer1.LastName;
                ViewBag.CustomerName = ViewData["CustomerName"].ToString();
                ViewData["CustomerID"] = customer1.CustomerID;
                ViewBag.CustomerID = ViewData["CustomerID"].ToString();
                //Debug.WriteLine("This is definitely something" + (string)ViewBag.CustomerName); //Used to check does the code run to this location
            }

            string customerID = HttpContext.Session.GetString("username");
            DBTester dbtester = new DBTester(dbcontext);
            List<PurchaseHist> cart = dbtester.GetCartProducts(customerID);
            return View("PurchaseHistory", cart);
        }

        public Customer FindCustomer(string login)
        {
            Customer customer = dbcontext.Customers.Find(login);

            return customer;

        }

    }
}