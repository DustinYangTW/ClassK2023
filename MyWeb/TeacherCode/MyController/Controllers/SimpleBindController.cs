using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class SimpleBindController : Controller
    {
        //使用HttpGet
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string ID, string Name, int Price)
        {

            ViewData["Show"]=ID+", "+Name+", "+Price;

            return View();
        }
    }
}
