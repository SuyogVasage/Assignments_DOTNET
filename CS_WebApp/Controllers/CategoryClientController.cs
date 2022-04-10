using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace CS_WebApp.Controllers    
{
    public class CategoryClientController : Controller
    {
        HttpClient client;
        public CategoryClientController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var cats = await client.GetFromJsonAsync<List<Category>>("https://localhost:7092/api/Category");
            return View(cats);
        }
        public IActionResult Create()
        {
            return View(new Category());

        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var response = await client.PostAsJsonAsync<Category>("https://localhost:7092/api/Category", category);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Success";
                return View(category);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cats = await client.GetFromJsonAsync<Category>("https://localhost:7092/api/Category/"+id);
            return View(cats);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category, int id)
        {
            category.CategoryRowId = id;
            var response = await client.PutAsJsonAsync<Category>("https://localhost:7092/api/Category/"+id, category);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "No Success";
                return View(category);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cats = await client.GetFromJsonAsync<Category>("https://localhost:7092/api/Category/"+id);
            return View(cats);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Category cat)
        {
            var response = await client.DeleteAsync("https://localhost:7092/api/Category/" + id);
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
