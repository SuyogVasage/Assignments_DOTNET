using Microsoft.AspNetCore.Mvc;
using Naukari_24March.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Naukari_24March.CustomSession;
using Naukari_24March.Services;
using System.Linq;
using System;

namespace Naukari_24March.Controllers  
{
    public class FileUploadController : Controller
    {
        IWebHostEnvironment hostEnvironment;

        private readonly IService<PersonalInfo, int> personalInfoService;
        private readonly IService<EducationInfo, int> educationService;
        private readonly IService<ProfessionalInfo, int> professionalService;
        
        public FileUploadController(IWebHostEnvironment hostEnvironment, IService<PersonalInfo, int> personalInfoService, IService<EducationInfo, int> educationService, IService<ProfessionalInfo, int> professionalService)
        {
            this.hostEnvironment = hostEnvironment;
            this.personalInfoService = personalInfoService;
            this.educationService = educationService;
            this.professionalService = professionalService;
        }
        public IActionResult Index()
        {
            List<ProfileData> profiles = new List<ProfileData>();
            return View(profiles);
        }

        public IActionResult UploadImg()
        {
            ProfileData data = new ProfileData();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UploadImg(ProfileData data)  
        {

            IFormFile file = data.ProfilePicture;

            // if()
            if (file.Length > 0 && file.Length < 500000)
            {
                // REad the Uploaded File Name
                var postedFileName = ContentDispositionHeaderValue
                  .Parse(file.ContentDisposition)
                    .FileName.Trim('"');
                FileInfo fileInfo = new FileInfo(postedFileName);

                if (fileInfo.Extension == ".jpg")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "Image", postedFileName);
                    HttpContext.Session.SetString("ImgPath", finalPath);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = file.FileName;

                    data.UploadStatus = "File is Uploaded Successfully";
                }
            }
            else
            {
                data.UploadStatus = "File is Upload Failed";
            }
            return RedirectToAction("UploadResume"); 
        }
        public IActionResult UploadResume()
        {
            ProfileData data = new ProfileData();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UploadResume(ProfileData data)
        {

            IFormFile file = data.ProfilePicture;

            // if()
            if (file.Length > 0 && file.Length < 5000000)
            {
                // REad the Uploaded File Name
                var postedFileName = ContentDispositionHeaderValue
                  .Parse(file.ContentDisposition)
                    .FileName.Trim('"');
                FileInfo fileInfo = new FileInfo(postedFileName);

                if (fileInfo.Extension == ".pdf")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "Resume", postedFileName);
                    HttpContext.Session.SetString("ResumePath", finalPath);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = file.FileName;

                    data.UploadStatus = "File is Uploaded Successfully";
                }
            }
            else
            {
                data.UploadStatus = "File is Upload Failed";
            }

            var personalInfo1 = HttpContext.Session.GetObject<PersonalInfo>("Personal");
            personalInfo1.ImgPath = Convert.ToString(HttpContext.Session.GetString("ImgPath"));
            personalInfo1.ResumePath = Convert.ToString(HttpContext.Session.GetString("ResumePath"));
            var result = personalInfoService.CreateAsync(personalInfo1).Result;

            int id = personalInfoService.GetAsync().Result.ToList().OrderByDescending(x => x.CandidateId).Select(s => s.CandidateId).FirstOrDefault();

            var education = HttpContext.Session.GetObject<EducationInfo>("Education");
            education.CandidateId = id;
            var result1 = educationService.CreateAsync(education).Result;

            var professional = HttpContext.Session.GetObject<ProfessionalInfo>("Professional");
            professional.CandidateId = id;
            var result2 = professionalService.CreateAsync(professional).Result;

            return RedirectToAction("Index", "Home");
        }
    }
}

