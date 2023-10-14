using Microsoft.AspNetCore.Mvc;

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
            ViewData["Msg"] = "沒有上傳任何檔案，或者是上傳失敗";
            if (photo != null)
            {
                //FileName主檔名與副檔名
                FileInfo photoFile = new FileInfo(photo.FileName);
                //驗證副檔名
                if(photoFile.Extension.ToUpper() == ".JPG" ||photoFile.Extension.ToUpper() == ".PNG")
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Photos");
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileNameWithPath = Path.Combine(path, photoFile.Name);
                    //透過FileStream，複製檔案的地方
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    ViewData["Msg"] = "上傳成功";
                    return View();
                }
            }
            return View();
        }
    }
}
