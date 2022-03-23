using SuperMarket_23March.Models;
using SuperMarket_23March.Services;
using SuperMarket_23March.SessionExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket_23March.Controllers
{
    public class ProductController : Controller
    {

        IService<Product, int> product;
        public ProductController(IService<Product, int> prd)
        {
            product = prd;
        }
        // GET: /<controller>/
        // The CategoryId will be retrieved from the session and Products will 
        //be displayed based on the selected CategoryId
        public IActionResult Index()
        {
            var catId = HttpContext.Session.GetInt32("CategoryId");
            List<Product> Products = null;
            if (catId != 0)
            {
                Products = product.Get().Where(p => p.CategoryId == catId).ToList();
            }
            return View(Products);
        }

        // This method will redirect to the Index view of the BillGenerator
        // The method will add UnitPrice and BillDetails object in the Session
        public IActionResult SelectForPurchase(int id)
        {
            var prd = product.Get(id);
            var billDetails = new BillDetail()
            {
                ProductId = id,
                ProductName = prd.ProductName,
                Quantity = 0,
                RowPrice = 0
            };
            HttpContext.Session.SetInt32("UnitPrice", prd.UnitPrice);
            HttpContext.Session.SetSessionData<BillDetail>("SelProduct", billDetails);
            return RedirectToAction("Index", "BillGenerator");
        }


    }
}
