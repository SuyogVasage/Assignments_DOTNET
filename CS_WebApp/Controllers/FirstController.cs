using Microsoft.AspNetCore.Mvc;

namespace CS_WebApp.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
