using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;
using System.Linq;
using System.Collections.Generic;

namespace Naukari_24March.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IService<PersonalInfo, int> personalInfoService;
        private readonly IService<EducationInfo, int> educationService;

        public PersonalInfoController(IService<PersonalInfo, int> personalInfoService, IService<EducationInfo, int> educationService)
        {
            this.personalInfoService = personalInfoService;
            this.educationService = educationService;
        }
        public IActionResult Index()
        {
            var pInfo = new PerEdu();
            
            pInfo.eduInfos= educationService.GetAsync().Result.ToList();
            pInfo.personalInfos = personalInfoService.GetAsync().Result.ToList();
            foreach (var item in pInfo.eduInfos)
            {
                if(item.MastersName == null)
                {
                    string HighQ = item.DegreeName;
                }
                else
                {
                    string HighQ = item.MastersName;
                }
            }
            var Resultant = from p in pInfo.personalInfos
                            join e in pInfo.eduInfos on
                            p.CandidateId equals e.CandidateId
                            select new
                            {
                                CandidateID = p.CandidateId,
                                FullName = p.FullName,
                                MobileNo = p.MobileNo,
                                Email = p.Email,
                                Highest_Qualification = e.DegreeName,
                                ImgPath = p.ImgPath
                            };
            pInfo.ShowInfos = new List<ShowInfo>();
            //List<ShowInfo> infoList = new List<ShowInfo>();
            foreach (var d in Resultant)
            {
                pInfo.ShowInfos.Add(new ShowInfo() { CandidateId = d.CandidateID, FullName = d.FullName, MobileNo = d.MobileNo, Email = d.Email, Highest_Qualification = d.Highest_Qualification, ImgPath = d.ImgPath});
            }
            return View(pInfo);
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
