using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using System.Diagnostics;

namespace MyWebAPI.Controllers
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


//MyWebAPI專案進行步驟

//1     使用DB First建立 Model

//1.1   建立專案與資料庫的連線
//1.1.1 使用NuGet(專案名稱上按右鍵→管理NuGet套件)安裝下列套件
//      (1) Microsoft.EntityFrameworkCore.SqlServer
//      (2) Microsoft.EntityFrameworkCore.Tools
//1.1.2 到套件管理器主控台(檢視 > 其他視窗 > 套件管理器主控台)下指令
//      Scaffold-DbContext "Data Source=伺服器位址;Database=資料庫名稱;Trusted_Connection=True;TrustServerCertificate=True;User ID=帳號;Password=密碼" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -NoOnConfiguring -UseDatabaseNames -NoPluralize -Force
//      若成功的話，會看到Build succeeded.字眼，並在Models資料夾裡看到dbStudentsContext.cs(描述資料庫)及tStudent.cs(描述資料表)
//1.1.3 將連線字串寫在appsettings.json檔中
//1.1.4 在Program.cs加入使用appsettings.json中的連線字串程式碼(這段必須寫在var builder這行後面)


//2     製作我的第一個Restful API(Web API)

//2.1   建立CRUD API Ccontroller 
//2.1.1 在Controllers資料夾上按右鍵→加入→控制器
//2.1.2 左側選單點選「API」→ 中間主選單選擇「執行讀取/寫入動作的API控制器」→按下「加入」鈕
//2.1.3 檔名使用預設的ValuesController.cs 即可，按下「新增」鈕
//      ※我們會得到一個已經撰寫好基本CRUD架構的API Ccontroller※
//      ※該Ccontroller的撰寫風格符合Rest，使用Get、Get/{id}、Post、Put、Delete 進行各項動作※

//2.2   安裝Swagger Tool
//2.2.1 使用NuGet(專案名稱上按右鍵→管理NuGet套件)安裝Swashbuckle.AspNetCore套件
//2.2.2 在Program.cs中註冊及啟用Swagger
//2.2.3 安裝完後請執行本專案讓伺服器執行
//2.2.4 在網址列輸入http://localhost:xxxx/swagger/index.html (其中xxxx是您的port)
//2.2.5 測試及瞭解Swagger
//      ※Swagger是由一家叫SmartBear的公司所發行，屬於無償使用的OpenAPI套件，以使用於API開發時的測試※
//      ※以往開發多使用Postman這個軟體進行API測試，目前Swagger成為主流※   
//2.2.6 修改Post、Put及Delete Action
//2.2.7 使用Swagger Tool來進行ValuesController API的操作測試
//      ※Web API因為沒有UI，所以只能就Get的動作進行測試，無法對Post、Put及Delete的動作進行測試※ 
//      ※因此這裡的操作目的是熟悉Swagger的用法，以利Web API在開發時能使用它來進行測試※


//3     製作tStudent資料CRUD 的 Restful API(Web API)

//3.1   建立Department API Ccontroller 
//3.1.1 在Controllers資料夾上按右鍵→加入→控制器
//3.1.2 左側選單點選「API」→ 中間主選單選擇「使用Entity Framework執行動作的API控制器」→按下「加入」鈕
//3.1.3 在對話方塊中設定如下
//      模型類別: Department(MyWebAPI.Models)
//      資料內容類別: dbStudentsContext(MyWebAPI.Models)
//      控制器名稱使用預設即可(DepartmentsController)
//      按下「新增」鈕


//3.2   建立tStuden API Ccontroller 
//3.2.1 在Controllers資料夾上按右鍵→加入→控制器
//3.2.2 左側選單點選「API」→ 中間主選單選擇「使用Entity Framework執行動作的API控制器」→按下「加入」鈕
//3.2.3 在對話方塊中設定如下
//      模型類別: tStudent(MyWebAPI.Models)
//      資料內容類別: dbStudentsContext(MyWebAPI.Models)
//      控制器名稱使用預設即可(tStudentsController)
//      按下「新增」鈕
//3.2.4 使用Swagger Tool分別對DepartmentsController及tStudentsController API進行操作測試


////////////////////這條是前後端工程師分隔線////////////////////////////////

//3.3   製作顯示學生資料列表的頁面
//3.3.1 修改GettStudent Action
//3.3.2 在網站根目錄wwwroot內新增html網頁Student.html
//3.3.3 載入Bootstrap CSS及icon用的CSS
//3.3.4 載入jQuery函式庫及Bootstrap的JS主程式
//3.3.5 依自己的喜好編輯UI並利用Bootstrap進行網頁切版
//      ※請使用課程中所教過的HTML、CSS、Bootstrap進行網頁畫面的編輯※ 
//      ※這是純前端的HTML網頁，無法使用Razor及Tag Helper※ 
//3.3.6 撰寫讀取Department資料的程式，並操作DOM來進行左側選單的安排
//3.3.7 撰寫讀取tStudent資料的程式，並操作DOM來進行學生資料列表的呈現
//3.3.8 測試是否能正常顯示
//      ※學生資料需以所選的科系來進行顯示，預設顯示第一個科系的學生資料※
//      ※由於全部都是純前端的程式，因此所有動作都得撰寫相對應行為的程式※
//      ※這裡會有相當多的連動，因此很多動作需透過參數的傳遞才能完成※
//      ※在各項功能逐建被建立的過程，撰寫程式時將會發現時不時會出現原本不存在的Bug，因此會不斷要修正※
//      ※請多看幾次影片講解，才能記住並建立應有概念※