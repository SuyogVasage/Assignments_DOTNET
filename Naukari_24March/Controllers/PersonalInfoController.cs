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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Naukari_24March.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IService<PersonalInfo, int> personalInfoService;
        private readonly IService<EducationInfo, int> educationService;
        private readonly IService<ProfessionalInfo, int> professionalService;

        public PersonalInfoController(IService<PersonalInfo, int> personalInfoService, IService<EducationInfo, int> educationService, IService<ProfessionalInfo, int> professionalService)
        {
            this.personalInfoService = personalInfoService;
            this.educationService = educationService;
            this.professionalService = professionalService;
        }

        [Authorize(Roles = "Employer")]
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

        [Authorize(Roles = "JobSeeker")]
        public IActionResult Create()
        {
            GenderItem();
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
            GenderItem();
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

        [Authorize(Roles ="JobSeeker")]
        public IActionResult Details()
        {
            ShowAllInfo show1 = new ShowAllInfo();
            var Loginid = HttpContext.Session.GetString("LoginID");
            var id = personalInfoService.GetAsync().Result.Where(x => x.UserId == Loginid).Select(y=>y.CandidateId).FirstOrDefault();
            if(id == 0)
            {
                ViewBag.Message = "First Add Your Information";
                return View(show1);
            }
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

        public IActionResult Edit()
        {
            var Loginid = HttpContext.Session.GetString("LoginID");
            var id = personalInfoService.GetAsync().Result.Where(x => x.UserId == Loginid).Select(y => y.CandidateId).FirstOrDefault();
            
            var result = personalInfoService.GetAsync(id).Result;
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(PersonalInfo per)
        {
            if (ModelState.IsValid)
            {
                var Loginid = HttpContext.Session.GetString("LoginID");
                var id = personalInfoService.GetAsync().Result.Where(x => x.UserId == Loginid).Select(y => y.CandidateId).FirstOrDefault();
                per.CandidateId = id;
                var result = personalInfoService.UpdateAsync(id, per).Result;
                return RedirectToAction("Details");
            }
            else
            {
                return View(per);
            }

        }

        public void GenderItem()
        {
            List<SelectListItem> Gender = new List<SelectListItem>();
            Gender.Add(new SelectListItem() { Text = "Male", Value = "Male" });
            Gender.Add(new SelectListItem() { Text = "Female", Value = "Female" });
            Gender.Add(new SelectListItem() { Text = "Transgender", Value = "Transgender" });
            Gender.Add(new SelectListItem() { Text = "No to Answer", Value = "Not to Anwser" });

            ViewBag.Gender = Gender;
        }
    }
}
