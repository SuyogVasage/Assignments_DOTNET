using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;
using System;
namespace CS_WebApp.Controllers
{
    public class RequestLogController : Controller
    {
        private readonly IService<RequestLog, int> logService;  
        
        public RequestLogController(IService<RequestLog, int> service)
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
