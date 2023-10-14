using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class MultFileUpLoadController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile[] Photos)
        {
            ViewData["Msg"] = "沒有上傳任何檔案，或者是上傳失敗";
            if (Photos.Length != 0)
            {
                #region 參數初始化，以防止重複宣告
                FileInfo photoFile;//防止重複宣告
                string fileNameWithPath = string.Empty;
                string path = string.Empty;
                int Count = 0;
                #endregion
                FileStream stream;
                foreach (var photo in Photos)
                {
                    //FileName主檔名與副檔名
                    photoFile = new FileInfo(photo.FileName);
                    //驗證副檔名
                    if (photoFile.Extension.ToUpper() == ".JPG" || photoFile.Extension.ToUpper() == ".PNG")
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        fileNameWithPath = Path.Combine(path, photoFile.Name);
                        //透過FileStream，複製檔案的地方
                        using (stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            photo.CopyTo(stream);
                        }
                    }
                    Count++;
                }
                ViewData["Msg"] = $"{Count}筆上傳成功";
                return View();
            }
            return View();
        }
    }
}
