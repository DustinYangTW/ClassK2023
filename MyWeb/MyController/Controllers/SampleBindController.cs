using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class SampleBindController : Controller
    {
        /// <summary>
        /// 使用HttpGet
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 使用HttpPost
        /// 必須要是Post的請求，才會走這個方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(string ID,String Name,int Price)
        {
            ViewData["Show"] = $"{ID}, {Name}, {Price}";
            return View();
        }
    }
}
