using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Naukari_24March.Services;
using System;
using Microsoft.AspNetCore.Http;
using Naukari_24March.CustomSession;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ListItem();

            var per = HttpContext.Session.GetObject<EducationInfo>("Education");
            if (per == null)
            {
                //var user = new PersonalInfo();
                return View(per);
            }
            return View(per);
        }

        [HttpPost]
        public IActionResult Create(EducationInfo eduInfo)
        {
            ListItem();
            if (ModelState.IsValid)
            {
                //var result = educationService.CreateAsync(eduInfo).Result;
                HttpContext.Session.SetObject<EducationInfo>("Education", eduInfo);
                return RedirectToAction("Create", "ProfessionalInfo");
            }
            else
            {
                return View(eduInfo);
            }
            
        }

        public void ListItem()
        {
            List<SelectListItem> Year = new List<SelectListItem>();
            for (int i = 2010; i <= 2022; i++)
            {
                Year.Add(new SelectListItem() { Text = $"{i}", Value = $"{i}" });
            }
            ViewBag.Passyear = Year;

            List<SelectListItem> DegreeName = new List<SelectListItem>();
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech EXTC", Value = "BE/BTech EXTC" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech IT", Value = "BE/BTech IT" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech Electronics", Value = "BE/BTech Electronics" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech Electrical", Value = "BE/BTech Electrical" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech CS", Value = "BE/BTech CS" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech Computer", Value = "BE/BTech Computer" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech Mechanical", Value = "BE/BTech Mechanical" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech Civil", Value = "BE/BTech Civil" });
            DegreeName.Add(new SelectListItem() { Text = "BE/BTech Chemical", Value = "BE/BTech Chemical" });
            DegreeName.Add(new SelectListItem() { Text = "Bsc IT", Value = "Bsc IT" });
            DegreeName.Add(new SelectListItem() { Text = "BSc Maths", Value = "BSc Maths" });
            DegreeName.Add(new SelectListItem() { Text = "BSc Chemistry", Value = "BSc Chemistry" });
            DegreeName.Add(new SelectListItem() { Text = "BSc Physics", Value = "BSc Physics" });
            DegreeName.Add(new SelectListItem() { Text = "BSc Physics", Value = "BSc Physics" });
            DegreeName.Add(new SelectListItem() { Text = "BCom", Value = "BCom" });
            DegreeName.Add(new SelectListItem() { Text = "BA", Value = "BA" });
            DegreeName.Add(new SelectListItem() { Text = "BCA", Value = "BCA" });

            ViewBag.DegreeName = DegreeName;

            List<SelectListItem> MastersName = new List<SelectListItem>();
            MastersName.Add(new SelectListItem() { Text = "ME/MTech EXTC", Value = "ME/MTech EXTC" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech IT", Value = "ME/MTech IT" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech Electronics", Value = "ME/MTech Electronics" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech Electrical", Value = "ME/MTech Electrical" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech CS", Value = "ME/MTech CS" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech Computer", Value = "ME/MTech Computer" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech Mechanical", Value = "ME/MTech Mechanical" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech Civil", Value = "ME/MTech Civil" });
            MastersName.Add(new SelectListItem() { Text = "ME/MTech Chemical", Value = "ME/BMech Chemical" });
            MastersName.Add(new SelectListItem() { Text = "Msc IT", Value = "Msc IT" });
            MastersName.Add(new SelectListItem() { Text = "MSc Maths", Value = "MSc Maths" });
            MastersName.Add(new SelectListItem() { Text = "MSc Chemistry", Value = "MSc Chemistry" });
            MastersName.Add(new SelectListItem() { Text = "MSc Physics", Value = "MSc Physics" });
            MastersName.Add(new SelectListItem() { Text = "MSc Physics", Value = "MSc Physics" });
            MastersName.Add(new SelectListItem() { Text = "MCom", Value = "MCom" });
            MastersName.Add(new SelectListItem() { Text = "MA", Value = "MA" });
            MastersName.Add(new SelectListItem() { Text = "MCA", Value = "MCA" });

            ViewBag.MastersName = MastersName;
        }
    }
}
