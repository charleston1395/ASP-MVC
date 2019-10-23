using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model1.Models;

namespace Model1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var repo = new ProductRepository();
            var products = repo.GetAllProducts();

            return View(products);
        }
        public IActionResult ViewProduct(int id)
        {
            ProductRepository repo = new ProductRepository();
            Product product = repo.GetProduct(id);
            repo.UpdateProduct(product);



            return View(product);
        }
        public IActionResult OnSale()
        {
            var repo = new ProductRepository();
            var products = repo.GetOnSaleProducts();

            return View(products);
        }

        public IActionResult UpdateProduct(int id)
        {
            ProductRepository repo = new ProductRepository();
            Product product = repo.GetProduct(id);
            if (product == null)
            {
                return View("ProductNotFound");
            }
            
                return View(product);

                
        }

        public IActionResult UdateProductToDatabase(Product product)
        {
            ProductRepository repo = new ProductRepository();
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ID });
        }
        public IActionResult InsertProduct()
        {

        }

    }
}