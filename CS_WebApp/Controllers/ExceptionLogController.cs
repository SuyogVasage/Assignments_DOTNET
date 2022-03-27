using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;

namespace CS_WebApp.Controllers
{
    public class ExceptionLogController : Controller
    {
        private readonly IService<ExceptionLog, int> logService;
       
        public ExceptionLogController(IService<ExceptionLog, int> service)
        {
            logService = service;
        }
        public IActionResult Index()
        {
            var result = logService.GetAsync().Result;
            return View(result);
        }
    }
}
