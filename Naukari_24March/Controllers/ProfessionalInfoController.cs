using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;

namespace Naukari_24March.Controllers
{
    public class ProfessionalInfoController : Controller
    {
        private readonly IService<ProfessionalInfo, int> professionalService;
        public ProfessionalInfoController(IService<ProfessionalInfo, int> professionalService)
        {
            this.professionalService = professionalService;
        }
        public IActionResult Index()
        {
            var result = professionalService.GetAsync().Result;
            return View(result);
        }

        public IActionResult Create()
        {
            var user = new ProfessionalInfo();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(ProfessionalInfo professionalInfo)
        {
            //var result = professionalService.CreateAsync(professionalInfo).Result;
            HttpContext.Session.SetObject<ProfessionalInfo>("Professional", professionalInfo);
            return RedirectToAction("UploadImg", "Fileupload");
        }
    }
}
