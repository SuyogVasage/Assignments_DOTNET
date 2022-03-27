using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace CS_WebApp.Controllers
{
    public class FileUploadController : Controller
    {
        IWebHostEnvironment hostEnvironment;
        public FileUploadController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            List<ProfileData> profiles = new List<ProfileData>();
            return View(profiles);
        }

        public IActionResult Upload()
        {
            ProfileData data = new ProfileData();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Upload(ProfileData data)
        {
            // REad the Current Directtory that is mapped with WebServer
           // var folder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
            // Get the File Objet
            IFormFile file = data.ProfilePicture;
            // Process It
            // Always Check Length of file
            
           // if()
            if (file.Length > 0 && file.Length < 10000000)
            {
                // REad the Uploaded File Name
                var postedFileName = ContentDispositionHeaderValue
                  .Parse(file.ContentDisposition)
                    .FileName.Trim('"');
                    FileInfo fileInfo = new FileInfo(postedFileName);
                    
                if(fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "images", postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = file.FileName;
                }
                else
                if(fileInfo.Extension == ".pdf")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "PDF", postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = "pdf_icon.png";
                }
                else
                 if (fileInfo.Extension == ".txt")
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "Text", postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = "txt.jpg";
                }
                else
                {
                    var finalPath = Path.Combine(hostEnvironment.WebRootPath, "Others", postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        // Create a File into the folder
                        await file.CopyToAsync(fs);
                    }
                    data.FileName = "others_icon.jpg";
                }
                // set the file path as FolderName/FileName
                // var finalPath = Path.Combine(folder, postedFileName);

                data.UploadStatus = "File is Uploaded Successfully";
                
            }
            else
            {
                data.UploadStatus = "File is Upload Failed";
            }
            return View(data);
        }
    }
}
