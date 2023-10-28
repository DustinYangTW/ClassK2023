using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc;
using MyController.Models;

namespace MyController.Controllers
{
    public class FileUpLoadController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile photo)
        {
            ViewData["Message"] = "沒有上傳任何檔案!!";

            if (photo != null)
            {
                FileInfo photoFile = new FileInfo(photo.FileName);

                if (photoFile.Extension.ToLower() == ".jpg" || photoFile.Extension.ToLower() == ".png")
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos");

                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }


                    string fileNameWithPath = Path.Combine(path, photo.FileName);
                    using (var stream =new FileStream(fileNameWithPath,FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }

                    ViewData["Message"] = "上傳成功!!";

                    return View();


                }
                return View();

            }
         

            return View();
        }
    }
}
