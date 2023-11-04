using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class MultiFileUpLoadController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile[] photos)
        {
            ViewData["Message"] = "沒有上傳任何檔案!!";

            if (photos != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileInfo photoFile;
                string fileNameWithPath = "";
                FileStream stream;

                for (int i=0;i<photos.Length;i++)
                {

                    photoFile = new FileInfo(photos[i].FileName);

                    if (photoFile.Extension.ToLower() == ".jpg" || photoFile.Extension.ToLower() == ".png")
                    {

                        fileNameWithPath = Path.Combine(path, photos[i].FileName);
                        using (stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            photos[i].CopyTo(stream);
                        }

                        ViewData["Message"] += $"第{i+1}上傳成功!!";

                    }
                    
                }

                return View();

            }


            return View();
        }


        public IActionResult ShowPhoto()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos");
            DirectoryInfo d=new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles();

            string result = "";
            foreach(var item in files)
            {
                result += $"<img src='../Photos/{item.Name}' width='300'>";
            }

            ViewData["Show"] = result;

            return View();
        }



    }
}
