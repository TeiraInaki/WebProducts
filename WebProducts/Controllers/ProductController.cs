using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProducts.Models;

namespace WebProducts.Controllers
{
    public class ProductController : Controller
    {
        private ProductDbContext context = new ProductDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var prods = context.Products.ToList();
            return View("Index", prods);
        }

        //Index por categoria

        public ActionResult IndexByCategory(string category)
        {
            if (category == "")
            {
                return RedirectToAction("Index");
            }
            var products = (from p in context.Products where p.Category == category select p).ToList();

            return View("Index", products);
        }

        //Index por categoria y nombre

        public ActionResult IndexByCategoryName(string category, string name) 
        {
            if (category == "" || name == "")
            {
                return RedirectToAction("Index");
            }
            var products = (from p in context.Products where p.Category == category && p.ProductName == name select p).ToList();

            return View("Index", products);
        }


        //Create

        public ActionResult Create()
        {
            Product product = new Product();
            return View("Create", product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Create", product);
        }

        //Details

        public ActionResult Detail(int id)
        {
            var product = context.Products.Find(id);

            if (product != null)
            {
                return View("Detail", product);
            }
            else return HttpNotFound();
        }

        //Delete

        public ActionResult Delete(int id)
        {
            var product = context.Products.Find(id);

            if (product != null)
            {
                return View("Delete", product);
            }
            else return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = context.Products.Find(id);

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Edit

        public ActionResult Edit(int id)
        {
            var product = context.Products.Find(id);

            if (product != null)
            {
                return View("Edit", product);
            }
            else return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else return View("Edit", product);
        }
    }
}