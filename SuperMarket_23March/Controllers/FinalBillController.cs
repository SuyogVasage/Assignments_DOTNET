using SuperMarket_23March.Models;
using SuperMarket_23March.Services;
using SuperMarket_23March.SessionExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket_23March.Controllers
{
    public class FinalBillController : Controller
    {
        IBill finalBill;

        public FinalBillController(IBill fb)
        {
            finalBill = fb;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var selProducts = HttpContext.Session.GetSessionData<List<BillDetail>>("PurchasedProduct");

            var billMaster = new BillMaster();
            //Calculate the Total Bill Amount
            foreach (var item in selProducts)
            {
                billMaster.BillAmount += item.RowPrice;
            }

            billMaster.BillDetails = selProducts;

            finalBill.GenerateBill(billMaster, billMaster.BillDetails.ToArray());

            return View(billMaster);
        }


    }
}
