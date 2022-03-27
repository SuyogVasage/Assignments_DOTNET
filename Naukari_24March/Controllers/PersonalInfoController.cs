using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;
namespace Naukari_24March.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IService<PersonalInfo, int> personalInfoService;

        public PersonalInfoController(IService<PersonalInfo, int> personalInfoService)
        {
            this.personalInfoService = personalInfoService;
        }
        public IActionResult Index()
        {
            var result = personalInfoService.GetAsync().Result;
            return View(result);
        }

        public IActionResult Create()
        {
            var user = new PersonalInfo();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(PersonalInfo personalInfo)
        {
            //var result = personalInfoService.CreateAsync(personalInfo).Result;
            HttpContext.Session.SetObject<PersonalInfo>("Personal", personalInfo);
            
            return RedirectToAction("Create", "EducationalInfo");
        }
    }
}
