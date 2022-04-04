using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;
using System.Collections.Generic;

namespace Naukari_24March.Controllers
{
    public class ProfessionalInfoController : Controller
    {
        private readonly IService<ProfessionalInfo, int> professionalService;
        List<ProfessionalInfo> professionalInfos;   
        public ProfessionalInfoController(IService<ProfessionalInfo, int> professionalService)
        {
            this.professionalService = professionalService;
            professionalInfos = new List<ProfessionalInfo>();
        }
        public IActionResult Index()
        {
            var result = professionalService.GetAsync().Result;
            return View(result);
        }

        public IActionResult Create()
        {
            var per = HttpContext.Session.GetObject<ProfessionalInfo>("Professional");
            if (per == null)
            {
                //var user = new PersonalInfo();
                return View(per);
            }
            return View(per);
        }

        [HttpPost]
        public IActionResult Create(ProfessionalInfo professionalInfo)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObject<ProfessionalInfo>("Professional", professionalInfo);
                return RedirectToAction("UploadImg", "Fileupload"); 
            }
            else
            {
                return View(professionalInfo);
            }
        }
    }
}
