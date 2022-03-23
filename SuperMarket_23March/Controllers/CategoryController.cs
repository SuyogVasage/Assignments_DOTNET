using SuperMarket_23March.Models;
using SuperMarket_23March.Services;
using SuperMarket_23March.SessionExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket_23March.Controllers
{
    public class CategoryController : Controller
    {
        IService<Category, int> category;

        public CategoryController(IService<Category, int> cat)
        {
            category = cat;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var cats = category.Get();
            return View(cats);
        }
        //The LoadProducts method will create a new Session Key "CategoryId" and 
        // it will store the CategoryId in it. 
        // This method will redirect to the Index method of the Product Controller
        public IActionResult LoadProducts(int id)
        {
            HttpContext.Session.SetInt32("CategoryId", id);
            return RedirectToAction("Index", "Product");
        }
    }
}
