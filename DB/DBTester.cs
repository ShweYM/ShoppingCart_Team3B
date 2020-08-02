using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team3B_ShoppingCart.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Team3B_ShoppingCart.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Team3B_ShoppingCart.DB
{
    public class DBTester
    {
        public ShoppingCartContext dbcontext;

        public DBTester(ShoppingCartContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<Product> GetProducts()
        {
            //  dbcontext = new ShoppingCartContext();//
            List<Product> product = dbcontext.Products.Where(x => x.ProductName != null).ToList();

            List<PurchaseHist> pp = new List<PurchaseHist>();


            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }

        }

        public Product GetProductByID(string id)
        {
            //  dbcontext = new ShoppingCartContext();//
            Product product = dbcontext.Products.Where(x => x.ProductID == id).ToList().FirstOrDefault();

            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }

        }

        public List<Customer> GetCustomers(string customerid)
        {
            //  dbcontext = new ShoppingCartContext();
            List<Customer> customer = dbcontext.Customers.Where(x => x.CustomerID == customerid).ToList();
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }

        }

        public void StoreSessionId(Session session, string customerid, string sessionid)
        {
            Session session_check = dbcontext.Sessions.Where(
                x => x.SessionID == sessionid)
                .FirstOrDefault();
            if (session_check != null)
            {
                return;
            }
            session.SessionDateTime = DateTime.UtcNow;
            session.SessionID = sessionid;
            session.CustomerID = customerid;
            dbcontext.Add(session);
            dbcontext.SaveChanges();
        }

        public List<Product> GetSearchProducts(String productname)
        {
            //  dbcontext = new ShoppingCartContext();
            List<Product> product = dbcontext.Products.Where(x => x.ProductName.Contains(productname)).ToList();
            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public string GetDataFromCart(string username, string browsesession)
        {
            List<Cart> cartitem = dbcontext.Carts.Where(x => x.CustomerID == username && x.SessionID == browsesession).ToList();

            Sale saleitem = new Sale();

            if (cartitem.Count != 0)
            {
                //Add to Sale Table
                //saleitem.SaleID = 
                saleitem.CustomerID = username;
                saleitem.SalesDate = DateTime.Now;
                saleitem.PromoCode = null;
                saleitem.SalesQuantity = cartitem.Count();
                saleitem.SessionID = browsesession;
                dbcontext.Sales.Add(saleitem);
                dbcontext.SaveChanges();

                //Add to SaleDetails
                foreach (var item in cartitem)//1product => qty2
                {
                    for (var i = 0; i < item.CartQuantity; i++)
                    {
                        SaleDetail saledetail = new SaleDetail();
                        saledetail.SalesID = saleitem.SalesID;
                        saledetail.ProductID = item.ProductID;
                        saledetail.ActivationCode = Guid.NewGuid().ToString();
                        dbcontext.Add(saledetail);
                        dbcontext.SaveChanges();
                    }
                }

                //Delete From Cart

                List<Cart> getcustomer = dbcontext.Carts.Where(x => x.CustomerID == username).ToList();
                if (getcustomer.Count != 0)
                {
                    foreach (var customer in getcustomer)
                    {
                        dbcontext.Remove(customer);
                    }
                    dbcontext.SaveChanges();
                }

                return "Success";
            }
            return "Fail";
        }

        public List<PurchaseHist> GetCartProducts(string customerID)
        {
            //  dbcontext = new ShoppingCartContext();/

            var result = (from sale in dbcontext.Sales.Where(x => x.CustomerID == customerID)
                          join saleDetail in dbcontext.SaleDetails
                          on sale.SalesID equals saleDetail.SalesID
                          join product in dbcontext.Products
                          on saleDetail.ProductID equals product.ProductID
                          select new PurchaseHist
                          {
                              productname = product.ProductName, //dbcontext.Products.Where(x => x.ProductID == sale.ProductID).Select(a => a.ProductName).FirstOrDefault()
                              purchasedate = sale.SalesDate,
                              price = product.ProductPrice,
                              orderid = sale.SalesID,
                              description = product.Description,
                              salesquantity = sale.SalesQuantity,
                              activationcode = saleDetail.ActivationCode,
                              imageurl = product.ImageURL,
                           }).ToList();

            return result;

            //List<Sale> sales = dbcontext.Sales
            //    .Where(x => x.CustomerID == customerID).ToList();


            //List<PurchaseHist> pp_list = new List<PurchaseHist>();

            //foreach (Sale sale in sales)
            //{
            //    List<Product> products = dbcontext.Products
            //          .Where(x => x.ProductID == sale.ProductID).ToList();
            //    PurchaseHist pp1 = new PurchaseHist();
            //    foreach (Product product in products)
            //    {
            //        pp1.productname = product.ProductName;
            //        pp1.purchasedate = sale.SalesDate;
            //        pp1.price = product.ProductPrice;
            //        pp1.orderid = sale.SalesID;
            //        pp1.description = product.Description;
            //        pp1.salesquantity = sale.SalesQuantity;
            //        List<SaleDetail> saledetails = dbcontext.SaleDetails
            //            .Where(x => x.SalesID == sale.SalesID).ToList();
            //        foreach (SaleDetail saledetail in saledetails)
            //        {
            //            pp1.activationcode = saledetail.ActivationCode;
            //            pp_list.Add(pp1);
            //        }
            //    }
            //}

            //if (pp_list != null)
            //{
            //    return pp_list;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public List<CheckoutCart> ManageDataFromCartBSI(string browsesession)
        {
            //  dbcontext = new ShoppingCartContext();/
            List<Cart> cart = dbcontext.Carts
                .Where(x => x.SessionID == browsesession).ToList();

            List<CheckoutCart> productList = new List<CheckoutCart>();

            foreach (Cart c in cart)
            {
                Product products = dbcontext.Products
                      .Where(x => x.ProductID == c.ProductID).FirstOrDefault();
                CheckoutCart cc = new CheckoutCart();
                cc.ProductID = products.ProductID;
                cc.ProductName = products.ProductName;
                cc.ProductDescription = products.Description;
                cc.Image = products.ImageURL;
                cc.ProductPrice = products.ProductPrice;
                cc.ProductQty = c.CartQuantity;
                productList.Add(cc);                                                     
            }

            if (productList != null)
            {
                return productList;
            }
            else
            {
                return null;
            }
        }

        public List<CheckoutCart> ManageDataFromCartCID(string username)
        {
            //  dbcontext = new ShoppingCartContext();/
            List<Cart> cart = dbcontext.Carts
                .Where(x => x.CustomerID == username).ToList();

            List<CheckoutCart> productList = new List<CheckoutCart>();

            foreach (Cart c in cart)
            {
                Product products = dbcontext.Products
                      .Where(x => x.ProductID == c.ProductID).FirstOrDefault();
                CheckoutCart cc = new CheckoutCart();
                cc.ProductID = products.ProductID;
                cc.ProductName = products.ProductName;
                cc.ProductDescription = products.Description;
                cc.Image = products.ImageURL;
                cc.ProductPrice = products.ProductPrice;
                cc.ProductQty = c.CartQuantity;
                productList.Add(cc);
            }

            if (productList != null)
            {
                return productList;
            }
            else
            {
                return null;
            }
        }
        public int GetBasketNumberBySessionID(string sessionID)
        {
            //  dbcontext = new ShoppingCartContext();//
            List<Cart> cartList = dbcontext.Carts
                .Where(x => x.SessionID == sessionID).ToList();

            int sum = 0;
            foreach (Cart c in cartList)
            {
                sum += c.CartQuantity;
            }
            return (sum);
        }
    }
}
