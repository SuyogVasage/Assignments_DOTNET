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
            if(data.ProfilePicture == null)
            {
                data.UploadStatus = "File Upload is Failed";
                return View(data);
            }
            
            if (file.Length > 0 && file.Length < 500000)
            {
                // REad the Uploaded File Name
                var postedFileName = ContentDispositionHeaderValue
                  .Parse(file.ContentDisposition)
                    .FileName.Trim('"');
                FileInfo fileInfo = new FileInfo(postedFileName);

                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "Image", postedFileName);
                    
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = file.FileName;
                    var ImgPath = @$"~/Image/{file.FileName}";
                    HttpContext.Session.SetString("ImgPath", ImgPath);
                    data.UploadStatus = "File is Uploaded Successfully";
                    return RedirectToAction("UploadResume");
                }
                else
                {
                    data.UploadStatus = "File Upload is Failed";
                    return View(data);
                }
            }
            else
            {
                data.UploadStatus = "File Upload is Failed";
                return View(data);
            }
            
            
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
            if (data.ProfilePicture == null)
            {
                data.UploadStatus = "File Upload is Failed";
                return View(data);
            }

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
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = file.FileName;
                    var ResumePath = @$"~/Resume/{file.FileName}";
                    HttpContext.Session.SetString("ResumePath", ResumePath);

                    data.UploadStatus = "File is Uploaded Successfully";
                    return RedirectToAction("UploadData");
                }
                else
                {
                    data.UploadStatus = "File Upload is Failed";
                    return View(data);
                }
            }
            else
            {
                data.UploadStatus = "File Upload is Failed";
                return View(data);
            }
        }


        public IActionResult UploadData()  
        {
            Upload upload = new Upload();

            var personalInfo1 = HttpContext.Session.GetObject<PersonalInfo>("Personal");
            personalInfo1.ImgPath = Convert.ToString(HttpContext.Session.GetString("ImgPath"));
            personalInfo1.ResumePath = Convert.ToString(HttpContext.Session.GetString("ResumePath"));
            personalInfo1.Status = "Looking For Job";
            personalInfo1.UserId = HttpContext.Session.GetString("LoginID");
            personalInfo1.Email = HttpContext.Session.GetString("EmailID");


            var result = personalInfoService.CreateAsync(personalInfo1).Result;

            int id = personalInfoService.GetAsync().Result.ToList().OrderByDescending(x => x.CandidateId).Select(s => s.CandidateId).FirstOrDefault();

            var education = HttpContext.Session.GetObject<EducationInfo>("Education");
            education.CandidateId = id;
            var result1 = educationService.CreateAsync(education).Result;

            var professional = HttpContext.Session.GetObject<ProfessionalInfo>("Professional");
            professional.CandidateId = id;

            var result2 = professionalService.CreateAsync(professional).Result;

            HttpContext.Session.Remove("Personal");
            HttpContext.Session.Remove("Education");
            HttpContext.Session.Remove("Professional");
            if (result != null && result1 != null && result2 != null)
            {
                upload.UploadStatus = "Data Uploaded Successfully";
                ViewBag.ID = id;
            }
            else
            {
                upload.UploadStatus = "Data Uploading Failed";
                ViewBag.ID = "Not Found";

            }
            return View(upload);
        }

    }
}

