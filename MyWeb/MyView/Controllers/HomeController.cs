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
        /// 需要把運算邏輯抽離Controller，這樣才能把邏輯分離開來(Action 主要任務只有判斷)，不能處理太多事情
        /// </summary>
        /// <returns></returns>
        private List<NightMarket> Get_NightMarkets_Datas()
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
            return nightMarkets;
        }

        public IActionResult Index()
        {
            List<NightMarket> nightMarkets = Get_NightMarkets_Datas();
            return View(nightMarkets);
        }

        public IActionResult Display(string id)
        {

            // select * from NightMarket where id='A01'

            List<NightMarket> nm = Get_NightMarkets_Datas();

            //Linq Extension
            var result = nm.Where(m => m.Id == id).FirstOrDefault();

            return View(result);
        }


        public IActionResult Razor()
        {
            return View();
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