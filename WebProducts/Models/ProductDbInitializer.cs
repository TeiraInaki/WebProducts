using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace WebProducts.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            var products = new List<Product> {
            new Product
            {
                Category = "Electronics",
                ProductName = "Sony",
                Description = "32'' LCD TV",
                AvailableDate = new DateTime(2010, 1, 1)
            },
            new Product
            {
                Category = "Laptops",
                ProductName = "Asus",
                Description = "Zenbook",
                AvailableDate = new DateTime(2012, 1, 2)
            },
            new Product
            {
                Category = "Electronics",
                ProductName = "Samsung",
                Description = "46'' LED TV",
                AvailableDate = new DateTime(2011, 6, 1)
            }
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}