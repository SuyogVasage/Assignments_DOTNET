using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;

namespace Naukari_24March.Controllers
{
    public class EducationalInfoController : Controller
    {
        private readonly IService<EducationInfo, int> educationService; 
        public EducationalInfoController(IService<EducationInfo, int> educationService)
        {
            this.educationService = educationService;
        }
        public IActionResult Index()
        {
            var result = educationService.GetAsync().Result;
            return View(result);
        }

        public IActionResult Create()
        {
            var user = new EducationInfo();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(EducationInfo eduInfo)
        {
            //var result = educationService.CreateAsync(eduInfo).Result;
            HttpContext.Session.SetObject<EducationInfo>("Education", eduInfo);
            return RedirectToAction("Create", "ProfessionalInfo");
        }
    }
}
