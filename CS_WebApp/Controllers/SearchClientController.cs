using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CS_WebApp.Controllers
{
    public class SearchClientController : Controller
    {
        HttpClient client;
        public SearchClientController()
        {
            client = new HttpClient();
        }


        public IActionResult Search()  
        {
            return View(new Category());
        }

        [HttpPost]
        public async Task<IActionResult> Search(Category cat)
        {
            HttpContext.Session.SetString("CatRowName", cat.CategoryName);
            return RedirectToAction("GetInfo");
        }


        public async Task<IActionResult> GetInfo()
        {
            string Name = HttpContext.Session.GetString("CatRowName");
            ViewBag.CatRowName = Name;
            var cats = await client.GetFromJsonAsync<List<Product>>("https://localhost:7092/api/Search/" + Name);
            if(cats.Count == 0)
            {
                ViewBag.Message = "Product Not Found";
                return View(cats);
            }
            else
            {
                return View(cats);
            }
            
        }

    }
}
