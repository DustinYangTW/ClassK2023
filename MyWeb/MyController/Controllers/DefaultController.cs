using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAry()
        {
            int[] score = { 90, 48, 6, 743641, 465, 31, 64, 316, 06, 46, 469, 84861, 465 };
            int sum = 0;
            string show = string.Empty;
            foreach (int i in score)
            {
                sum += i;
                show += i + ", ";
            }
            show += "總成績為" + sum;
            ViewData["Show"] = show;
            return View();
        }
    }
}
