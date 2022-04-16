using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;
using System.Collections.Generic;
using System.Linq;

namespace Naukari_24March.Controllers
{
    public class ProfessionalInfoController : Controller
    {
        private readonly IService<ProfessionalInfo, int> professionalService;
        private readonly IService<PersonalInfo, int> personalInfoService;
        public ProfessionalInfoController(IService<ProfessionalInfo, int> professionalService, IService<PersonalInfo, int> personalInfoService)
        {
            this.professionalService = professionalService;
            this.personalInfoService = personalInfoService;
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

        public IActionResult Edit()
        {
            var Loginid = HttpContext.Session.GetString("LoginID");
            var personid = personalInfoService.GetAsync().Result.Where(x => x.UserId == Loginid).Select(y => y.CandidateId).FirstOrDefault();
            var id = professionalService.GetAsync().Result.Where(x => x.CandidateId == personid).Select(y => y.InfoId).FirstOrDefault();
            var result = professionalService.GetAsync(id).Result;
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(ProfessionalInfo per)
        {
            if (ModelState.IsValid)
            {
                var Loginid = HttpContext.Session.GetString("LoginID");
                var personid = personalInfoService.GetAsync().Result.Where(x => x.UserId == Loginid).Select(y => y.CandidateId).FirstOrDefault();
                var id = professionalService.GetAsync().Result.Where(x => x.CandidateId == personid).Select(y => y.InfoId).FirstOrDefault();
                var result = professionalService.UpdateAsync(id, per).Result;
                return RedirectToAction("Details", "PersonalInfo");
            }
            else
            {
                return View(per);
            }

        }

        public IActionResult Delete()
        {
            var Loginid = HttpContext.Session.GetString("LoginID");
            var personid = personalInfoService.GetAsync().Result.Where(x => x.UserId == Loginid).Select(y => y.CandidateId).FirstOrDefault();
            var id = professionalService.GetAsync().Result.Where(x => x.CandidateId == personid).Select(y => y.InfoId).FirstOrDefault();
            var result = professionalService.GetAsync(id).Result;
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(ProfessionalInfo per)
        {
            var Loginid = HttpContext.Session.GetString("LoginID");
            var personid = personalInfoService.GetAsync().Result.Where(x => x.UserId == Loginid).Select(y => y.CandidateId).FirstOrDefault();
            var id = professionalService.GetAsync().Result.Where(x => x.CandidateId == personid).Select(y => y.InfoId).FirstOrDefault();
            var result = professionalService.DeleteAsync(id).Result;
            return RedirectToAction("Details", "PersonalInfo");
        }
    }
}
