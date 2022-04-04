using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Naukari_24March.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IService<PersonalInfo, int> personalInfoService;
        private readonly IService<EducationInfo, int> educationService;
        private readonly IService<ProfessionalInfo, int> professionalService;
        //private readonly IFormFile fileProvider;

        public PersonalInfoController(IService<PersonalInfo, int> personalInfoService, IService<EducationInfo, int> educationService, IService<ProfessionalInfo, int> professionalService)
        {
            this.personalInfoService = personalInfoService;
            this.educationService = educationService;
            this.professionalService = professionalService;
            //this.fileProvider = fileProvider;
        }
        public IActionResult Index()
        {
            var personalData = personalInfoService.GetAsync().Result.ToList();

            List<ShowInfo> details = new List<ShowInfo>();

            foreach (var item in personalData)
            {
                var edu = educationService.GetAsync().Result.Where(x => x.CandidateId == item.CandidateId).FirstOrDefault();
                var highestQualification = string.Empty;
                if (edu.MastersName == null)
                {
                    highestQualification = edu.DegreeName;
                }
                else 
                {
                    highestQualification = edu.MastersName;
                }
               
                ShowInfo info = new ShowInfo()
                {
                    CandidateId = item.CandidateId,
                    FullName = item.FullName,
                    MobileNo = item.MobileNo,
                    Email = item.Email,
                    Highest_Qualification = highestQualification,
                    ImgPath = item.ImgPath
                };
                details.Add(info);
            }
            return View(details);
        }

        public IActionResult Create()
        {
            var per = HttpContext.Session.GetObject<PersonalInfo>("Personal");
            if (per == null)
            {
                return View(per);
            }
            return View(per);
        }

        [HttpPost]
        public IActionResult Create(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObject<PersonalInfo>("Personal", personalInfo);
                return RedirectToAction("Create", "EducationalInfo"); 
            }
            else
            {
                return View(personalInfo);
            }
        }

        public IActionResult Details( int id)
        {
            var education = educationService.GetAsync().Result.ToList().Where(x=>x.CandidateId == id).FirstOrDefault();
            var personal = personalInfoService.GetAsync(id).Result;
            var professional = professionalService.GetAsync().Result.ToList().Where(x => x.CandidateId == id).FirstOrDefault();

            ShowAllInfo show = new ShowAllInfo()
            {
                CandidateID = personal.CandidateId,
                FullName = personal.FullName,
                MobileNo = personal.MobileNo,
                Email = personal.Email,
                Address = personal.Address,
                SscpassYear = education.SscpassYear,
                Sscpercentage = education.Sscpercentage,
                HscpassYear = education.HscpassYear,
                Hscpercentage = education.Hscpercentage,
                DiplomaPassYear = education.DiplomaPassYear,
                DiplomaPercentage = education.DiplomaPercentage,
                DegreeName = education.DegreeName,
                DegreePassYear = education.DegreePassYear,
                DegreePercentage = education.DegreePercentage,
                MastersName = education .MastersName,
                MastersPassYear = education.MastersPassYear,
                MastersPercentage = education.MastersPercentage,
                ExpInYears = professional.ExpInYears,
                Companies = professional.Companies,
                Projects = professional.Projects,
                ImgPath = personal.ImgPath,
            };
            return View(show);
        }
    }
}
