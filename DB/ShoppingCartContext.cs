using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team3B_ShoppingCart.Models;


namespace Team3B_ShoppingCart.DB
{
    public class ShoppingCartContext : DbContext
    {
        protected IConfiguration configuration;

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            ////unique name within a column
            model.Entity<Customer>().HasIndex(tbl => tbl.CustomerID).IsUnique();
            model.Entity<Session>().HasIndex(tbl => tbl.SessionID).IsUnique();
            model.Entity<Product>().HasIndex(tbl => tbl.ProductName).IsUnique();
            model.Entity<PromoCodeDetail>().HasIndex(tbl => tbl.PromoCodeDetailID).IsUnique();


            model.Entity<Cart>().HasKey(tbl => new { tbl.SessionID, tbl.ProductID });
            model.Entity<CartHistory>().HasKey(tbl => new { tbl.SessionID, tbl.IsDeletedProduct });
            //model.Entity<SaleDetail>().HasKey(tbl => new { tbl.SalesID, tbl.ProductID });
            model.Entity<Sale>().HasKey(tbl => new { tbl.SalesID });
            
            model.Entity<SaleDetail>().HasKey(tbl => new { tbl.SaleDetailID });

            // composite keys
            //model.Entity<CartHistory>().HasAlternateKey(tbl =>
            //    new { tbl.SessionID, tbl.IsDeletedProduct }
            //);
            //model.Entity<Cart>().HasAlternateKey(tbl =>
            //    new { tbl.SessionID, tbl.ProductID }
            //);
            //model.Entity<Sale>().HasAlternateKey(tbl =>
            //    new { tbl.SalesID, tbl.CustomerID }
            //);
            //model.Entity<SaleDetail>().HasAlternateKey(tbl =>
            //    new { tbl.SalesID, tbl.ProductID, tbl.ActivationCode }
            //);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartHistory> CartHistorys { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<BrowseSession> BrowseSessions { get; set; }
        public DbSet<LoginSession> LoginSessions { get; set; }
        public DbSet<PromoCodeDetail> PromoCodeDetails { get; set; }
    }   
}
