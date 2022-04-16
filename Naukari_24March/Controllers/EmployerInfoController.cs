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
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace Naukari_24March.Controllers
{
    public class EmployerInfoController : Controller
    {
        private readonly IService<EmployerInfo, int> empService;
        IWebHostEnvironment hostEnvironment;

        public EmployerInfoController(IService<EmployerInfo, int> empService, IWebHostEnvironment hostEnvironment)
        {
            this.empService = empService;
            this.hostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "JobSeeker")]
        public IActionResult Index()
        {
            var result = empService.GetAsync().Result;
            return View(result);
        }

        [Authorize(Roles = "Employer")]
        public IActionResult Create()
        {
            var emp = HttpContext.Session.GetObject<EmployerInfo>("Employer");
            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(EmployerInfo empInfo)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObject<EmployerInfo>("Employer", empInfo);
                return RedirectToAction("UploadLogo");
            }
            else
            {
                return View(empInfo);
            }
        }


        public IActionResult UploadLogo()
        {
            ProfileData data = new ProfileData();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UploadLogo(ProfileData data)
        {
            IFormFile file = data.ProfilePicture;
            if (data.ProfilePicture == null)
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
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "Logo", postedFileName);

                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = file.FileName;
                    var ImgPath = @$"~/Logo/{file.FileName}";
                    HttpContext.Session.SetString("LogoPath", ImgPath);
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

            var empInfo = HttpContext.Session.GetObject<EmployerInfo>("Employer");
            empInfo.LogoPath = HttpContext.Session.GetString("LogoPath");
            empInfo.UserId = HttpContext.Session.GetString("LoginID");
            var result = empService.CreateAsync(empInfo).Result;

            if(result != null)
            {
                upload.UploadStatus = "Data Uploaded Successfully";
            }
            else
            {
                upload.UploadStatus = "Data Uploading Failed";
            }

            return View(upload);
        }

        public IActionResult Edit(int id)
        {
            var result = empService.GetAsync(id).Result;
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployerInfo emp)
        {
            if (ModelState.IsValid)
            {
                var result = empService.UpdateAsync(id, emp).Result;
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }

        }

        public IActionResult Delete(int id)
        {
            var result = empService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id, EmployerInfo emp)
        {
            var result = empService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
        [Authorize (Roles ="Employer")]
        public IActionResult Details()
        {
            var id = HttpContext.Session.GetString("LoginID");
            var info = empService.GetAsync().Result.Where(x=>x.UserId == id).FirstOrDefault();
            
            return View(info);
        }

    }
}
