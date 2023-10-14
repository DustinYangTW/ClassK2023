using Microsoft.AspNetCore.Mvc;
using MyController.Models;

namespace MyController.Controllers
{
    public class ComplexController : Controller
    {
        /// <summary>
        /// 使用HttpGet
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View(new Product());
        }
        /// <summary>
        /// 使用HttpPost
        /// 必須要是Post的請求，才會走這個方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewData["Show"] = $"{product.ID}, {product.Name}, {product.Price}";
            return View();
        }
    }
}
