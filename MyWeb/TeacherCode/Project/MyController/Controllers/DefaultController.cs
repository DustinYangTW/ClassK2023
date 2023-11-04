using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class DefaultController : Controller
    {
        //這種函數是在Controller裡專用的函數, 稱作Action
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ShowAry()
        {
            int[] score = {78,90,20,100,66,97,85,45 };
            int sum = 0;

            string show = "";

            foreach(int s in score)
            {
                sum += s;
                show += s+", ";
            }
            show += "總成績為" + sum;

            ViewData["Show"] = show;

            return View();
        }


        public IActionResult ShowImage()
        {

            for (int i = 1; i <= 8; i++)
            {
                ViewData["Show"] += $"<a href='ShowImageIndex?aaa={i}'><img src='/images/{i}.jpg' width='200' class='img-thumbnail'></a>";

            }

            return View();
        }

        public IActionResult ShowImageIndex(int aaa)
        {
            string[] name = { "櫻桃鴨", "鴨油高麗菜", "鴨油麻婆豆腐", "櫻桃鴨握壽司", "片皮鴨捲三星蔥", "三杯鴨", "櫻桃鴨片肉", "慢火白菜燉鴨湯" };


            ViewData["Show"] = $"<img src='/images/{aaa}.jpg' class='img-thumbnail'>";
            ViewData["Name"] = name[aaa - 1];
            return View();
        }

    }
}
