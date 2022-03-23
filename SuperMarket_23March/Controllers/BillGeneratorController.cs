using SuperMarket_23March.Models;
using SuperMarket_23March.Services;
using SuperMarket_23March.SessionExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket_23March.Controllers
{
    public class BillGeneratorController : Controller
    {
        List<BillDetail> selProducts;

        public BillGeneratorController()
        {
            selProducts = new List<BillDetail>();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.UnitPrice = HttpContext.Session.GetInt32("UnitPrice");
            var billDetails = HttpContext.Session.GetSessionData<BillDetail>("SelProduct");
            if (billDetails != null)
            {
                selProducts = HttpContext.Session.GetSessionData<List<BillDetail>>("PurchasedProduct");
            }
            return View(billDetails);
        }

        [HttpPost]
        public IActionResult Index(BillDetail b, string purchase)
        {
            if (purchase == "Save and Continue Purchase")
            {
                //Check if the session contains List of purchased prducts
                selProducts = HttpContext.Session.GetSessionData<List<BillDetail>>("PurchasedProduct");
                if (selProducts == null)
                {
                    selProducts = new List<Models.BillDetail>();
                }

                //Save the selected product in Session
                selProducts.Add(b);
                HttpContext.Session.SetSessionData<List<BillDetail>>("PurchasedProduct", selProducts);
                //Go to the ProductMVC     
                return RedirectToAction("Index", "Product");
            }
            else if (purchase == "Save and CheckOut")
            {
                selProducts = HttpContext.Session.GetSessionData<List<BillDetail>>("PurchasedProduct");
                if (selProducts == null)
                {
                    selProducts = new List<Models.BillDetail>();
                }
                var selBill = HttpContext.Session.GetSessionData<BillDetail>("SelProduct");
                ViewBag.UnitPrice = HttpContext.Session.GetInt32("UnitPrice");
                selBill.Quantity = b.Quantity;
                selBill.RowPrice = b.RowPrice;
                selProducts.Add(selBill);
                HttpContext.Session.SetSessionData<List<BillDetail>>("PurchasedProduct", selProducts);
                return RedirectToAction("Index", "FinalBill");
            }
            return View();
        }
    }
}
