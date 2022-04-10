using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CS_WebApp.Controllers
{
    public class ProductClientController : Controller
    {
        HttpClient client;
        public ProductClientController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var cats = await client.GetFromJsonAsync<List<Product>>("https://localhost:7092/api/Product");
            return View(cats);
        }
        public IActionResult Create()
        {
            return View(new Product());

        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var response = await client.PostAsJsonAsync<Product>("https://localhost:7092/api/Product", product);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Success";
                return View(product);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cats = await client.GetFromJsonAsync<Product>("https://localhost:7092/api/Product/" + id);
            return View(cats);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, int id)
        {
            product.ProductRowId = id;
            var response = await client.PutAsJsonAsync<Product>("https://localhost:7092/api/Product/" + id, product);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Success";
                return View(product);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cats = await client.GetFromJsonAsync<Product>("https://localhost:7092/api/Product/" + id);
            return View(cats);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Product cat)
        {
            var response = await client.DeleteAsync("https://localhost:7092/api/Product/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Success";
                return View(id);
            }
        }

    }
}
