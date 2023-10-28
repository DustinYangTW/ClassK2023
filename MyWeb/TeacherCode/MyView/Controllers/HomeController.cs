﻿using Microsoft.AspNetCore.Mvc;
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


        //public class NightMarket
        //{
        //    public string Id { get; set; }
        //    public string Name { get; set; }
        //    public string Address { get; set; }
        //}

        private List<NightMarket> GetNightMarketsData()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };

            string[] name = { "瑞豐夜市", "新堀江商圈", "六合夜市", "青年夜市", "花園夜市", "大東夜市", "武聖夜市" };

            string[] address = { "813高雄市左營區裕誠路", "800高雄市新興區玉衡里", "800台灣高雄市新興區六合二路",
                "80652高雄市前鎮區凱旋四路758號", "台南市北區海安路三段533號", "台南市東區林森路一段276號",
                "台南市中西區武聖路69巷42號" };

            List<NightMarket> list = new List<NightMarket>();
            NightMarket nm;

            for (int i = 0; i < id.Length; i++)
            {
                nm = new NightMarket();
                nm.Id = id[i];
                nm.Name = name[i];
                nm.Address = address[i];

                list.Add(nm);
            }

            return list;
        }

        public IActionResult Index()
        {

            return View(GetNightMarketsData());
        }

        public IActionResult IndexRWD()
        {

            return View(GetNightMarketsData());
        }

        public IActionResult Display(string id)
        {

            // select * from NightMarket where id='A01'

            List<NightMarket> nm = GetNightMarketsData();

            //Linq Extension
            var result = nm.Where(m => m.Id == id).FirstOrDefault();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NightMarket nightMarket)
        {

            ViewData["Show"] = "<h1>" + nightMarket.Id + ", " + nightMarket.Name + ", " + nightMarket.Address + "</h1>";

            return View();
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