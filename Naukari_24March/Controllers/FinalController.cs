using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;
using System.Linq;

namespace Naukari_24March.Controllers
{
    public class FinalController : Controller
    {
        private readonly IService<PersonalInfo, int> personalInfoService;
        private readonly IService<EducationInfo, int> educationService;
        private readonly IService<ProfessionalInfo, int> professionalService;
        public FinalController(IService<PersonalInfo, int> personalInfoService, IService<EducationInfo, int> educationService, IService<ProfessionalInfo, int> professionalService)
        {
            this.personalInfoService = personalInfoService;
            this.educationService = educationService;
            this.professionalService = professionalService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var user = new ProfessionalInfo();
            var iuser = new EducationInfo();
            var iiuser = new ProfessionalInfo();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(PersonalInfo personalInfo, EducationInfo educationInfo,ProfessionalInfo professionalInfo)
        {
            //var personalInfo1 = HttpContext.Session.GetObject<PersonalInfo>("Personal");
            //personalInfo1.ImgPath = Convert.ToString(HttpContext.Session.GetString("ImgPath"));
            //personalInfo1.ResumePath = Convert.ToString(HttpContext.Session.GetString("ResumePath"));
            //var result = personalInfoService.CreateAsync(personalInfo).Result;

            //int id = personalInfoService.GetAsync().Result.ToList().OrderByDescending(x => x.CandidateId).Select(s => s.CandidateId).FirstOrDefault();

            //var education = HttpContext.Session.GetObject<EducationInfo>("Education");
            //education.CandidateId = id;
            //var result1 = educationService.CreateAsync(education).Result;

            //var professional = HttpContext.Session.GetObject<ProfessionalInfo>("Professional");
            //professional.CandidateId = id;
            //var result2 = professionalService.CreateAsync(professional).Result;

            //if (result != null && result1 != null && result2 != null)
            //{
            //    ViewBag.UploadStatus = "Data Uploaded Successfully";
            //}
            //else
            //{
            //    ViewBag.UploadStatus = "Data Uploading Failed";
            //}

            return RedirectToAction("Index", "Home");
        }
    }
}
