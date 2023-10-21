using Microsoft.AspNetCore.Mvc;
using MyView.Models;
using System.Diagnostics;

namespace MyView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 可以當成模型來做處理，這種通常都稱為DataModel
        /// 會有一些規則可以做資料驗證
        /// </summary>
        public class NightMarket
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? Address { get; set; }
        }

        public IActionResult Index()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };

            string[] name = { "瑞豐夜市", "新堀江商圈", "六合夜市", "青年夜市", "花園夜市", "大東夜市", "武聖夜市" };

            string[] address = { "813高雄市左營區裕誠路", "800高雄市新興區玉衡里", "800台灣高雄市新興區六合二路",
                "80652高雄市前鎮區凱旋四路758號", "台南市北區海安路三段533號", "台南市東區林森路一段276號",
                "台南市中西區武聖路69巷42號" };

            List<NightMarket> nightMarkets = new List<NightMarket>();
            for (int i = 0; i < id.Length; i++)
            {
                nightMarkets.Add(new NightMarket
                {
                    Id = id[i],
                    Name = name[i],
                    Address = address[i]
                });
            }

            return View(nightMarkets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}