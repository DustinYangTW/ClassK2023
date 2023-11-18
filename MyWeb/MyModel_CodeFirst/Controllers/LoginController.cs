using Microsoft.AspNetCore.Mvc;
using MyModel_CodeFirst.Models;
using Newtonsoft.Json;

namespace MyModel_CodeFirst.Controllers
{
    public class LoginController : Controller
    {
        //4.2.4 建立DbContext物件
        private readonly GuestBookContext _context;

        public LoginController(GuestBookContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            if(login == null)
            {
                return View();
            }

            //select * from Login where Account=@Account and Password=@Password

            var result = _context.Login.Where(m => m.Account == login.Account && m.Password == login.Password).FirstOrDefault();

            if(result == null)
            {
                ViewData["ErrorMsg"] = "帳號或密碼錯誤!!";
                return View();
            }

            //若帳號密碼正確,使用session物件進行登入成功狀態保留
            HttpContext.Session.SetString("Manager", JsonConvert.SerializeObject(result));


            return RedirectToAction("Index", "Books");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Manager");
            return RedirectToAction("Login", "Login");
        }
    }
}
