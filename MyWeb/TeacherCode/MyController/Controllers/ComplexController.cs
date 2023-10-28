using Microsoft.AspNetCore.Mvc;
using MyController.Models;

namespace MyController.Controllers
{
    public class ComplexController : Controller
    {
        //使用HttpGet
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {

            ViewData["Show"] = p.ID + ", " + p.Name + ", " + p.Price;

            return View();
        }


        public IActionResult Create2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create2(Product p)
        {

            ViewData["Show"] = p.ID + ", " + p.Name + ", " + p.Price;

            return View();
        }
    }
}
