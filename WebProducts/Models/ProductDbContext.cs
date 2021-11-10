using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebProducts.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("KeyDB") { }
        public DbSet<Product> Products { get; set; }
    }
}