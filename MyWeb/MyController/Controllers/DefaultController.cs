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
        public IActionResult ShowImage()
        {
            for(int i = 1; i < 9; i++)
            {
                ViewData["Show"] += $"<a href='/Default/ShowImageIndex?i={i}'><img src='../images/{i}.jpg' width='200' calss='img-thumbnail'/></a>";
            }

            return View();
        }

        public IActionResult ShowImageIndex(int i)
        {
            ViewData["Show"] += $"<img src='../images/{i}.jpg' width='200' calss='img-thumbnail'/>";
            return View();
        }
    }
}
