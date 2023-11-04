using Microsoft.AspNetCore.Mvc;
using MyModel_CodeFirst.Models;
using System.Diagnostics;

namespace MyModel_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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


//MyModel_CodeFirst專案進行步驟

//1. 使用Code First建立Model及資料庫

//1.1   在Models資料夾裡建立Book及ReBook兩個類別做為模型
//1.1.1 在Models資料夾上按右鍵→加入→類別，檔名取名為Book.cs，按下「新增」鈕
//1.1.2 設計Book類別的各屬性，包括名稱、資料類型及其相關的驗證規則及顯示名稱(DisplayName)
//1.1.3 在Models資料夾上按右鍵→加入→類別，檔名取名為ReBook.cs，按下「新增」鈕
//1.1.4 設計ReBook類別的各屬性，包括名稱、資料類型及其相關的驗證規則及顯示名稱(DisplayName)
//1.1.5 撰寫兩個類別間的關聯屬性做為未來資料表之間的關聯


//1.2   建立DbContext類別
//      ※安裝下列兩個套件※
//      (1)Microsoft.EntityFrameworkCore.SqlServer
//      (2)Microsoft.EntityFrameworkCore.Tools
//      ※與DB First安裝的套件一樣※
//1.2.1 在Models資料夾上按右鍵→加入→類別，檔名取名為GuestBookContext.cs，按下「新增」鈕
//1.2.2 撰寫GuestBookContext類別的內容
//      (1)須繼承DbContext類別
//      (2)撰寫建構子
//      (3)描述資料庫裡面的資料表
//1.2.3 在appsettings.json中撰寫資料庫連線字串
//1.2.4 在Program.cs內以依賴注入的寫法撰寫讀取連線字串的物件
//      ※注意程式的位置必須要在var builder = WebApplication.CreateBuilder(args);這句之後
//1.2.5 在套件管理器主控台(檢視 > 其他視窗 > 套件管理器主控台)下指令
//      (1)Add-Migration InitialCreate
//      (2)Update-database
//      ※第(1)項的「InitialCreate﹞是自訂的名稱，若執行成功會看到「Build succeeded.」※
//      ※另外會看到一個Migrations的資料夾及其檔案被建立在專案中，裡面紀錄著Migration的歷程※
//      ※若第(1)項指令執行成功才能執行第(2)項指令※
//      (3)至SSMS中查看是否有成功建立資料庫及資料表(目前資料表內沒有資料)
//      (4)先將資料庫刪除，並將專案中Migrations資料夾及內含檔案整個刪除


//1.3   創建Initializer物件建立初始(種子)資料(Seed Data)
//      ※※※我們可以在創建資料庫時就創建幾筆初始的資料在裡面以供開發時測試之用※※※

//1.3.1 在Models資料夾上按右鍵→加入→類別，檔名取名為SeedData.cs，按下「新增」鈕
//1.3.2 撰寫SeedData類別的內容
//      (1)撰寫靜態方法 Initialize(IServiceProvider serviceProvider)
//      (2)撰寫Book及ReBook資料表內的初始資料程式
//      (3)撰寫getFileBytes，功能為將照片轉成二進位資料
//1.3.3 在Program.cs撰寫啟用Initializer的程式(要寫在var app = builder.Build();之後)
//      ※這個Initializer的作用是建立一些初始資料在資料庫中以利測試，所以不一定要有Initializer※
//      ※注意:初始資料的照片放在SeedSourcePhoto資料夾中※
//1.3.4 建置專案，確定專案完全建置成功
//1.3.5 再次於套件管理器主控台(檢視 > 其他視窗 > 套件管理器主控台)下指令
//      (1)Add-Migration InitialCreate
//      (2)Update-database
//1.3.4 至SSMS中查看是否有成功建立資料庫及資料表(目前資料表內沒有資料)
//1.3.5 在瀏覽器上執行網站首頁以建立初始資料(若沒有執行過網站，初始資料不會被建立)
//1.3.6 再次至SSMS中查看資料表內是否有資料

//※※※※※※※※※※※※
//到這裡為止即是Model與DB皆定稿並實作完成
//有些人會很納悶，在實際開發時，我要如何用Code First來建立資料庫？因為我可能沒有資料庫的權限啊！
//事實上Code First或DB First都是在開發時間在Local端做的事情
//以Code First來說，我們只是利用它創建DB，再用已完成的DB產出DDL Script
//※※※※※※※※※※※※