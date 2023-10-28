﻿using Microsoft.AspNetCore.Mvc;
using MyModel_DBFirst.Models;
using System.Diagnostics;

namespace MyModel_DBFirst.Controllers
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


//MyModel_DBFirst專案進行步驟

//1.使用DB First建立 Model

//1.1 在SSMS中執行dbStudents.sql程式碼，建立範例資料庫dbStudents，內含一個tStudent資料表

//1.2 建立專案與資料庫的連線
//1.2.1 使用NuGet(專案名稱上按右鍵→管理NuGet套件)安裝下列套件
//      (1) Microsoft.EntityFrameworkCore.SqlServer
//      (2) Microsoft.EntityFrameworkCore.Tools

//1.2.2 到套件管理器主控台(檢視 > 其他視窗 > 套件管理器主控台)下指令
//      Scaffold-DbContext "Data Source=伺服器位址;Database=資料庫名稱;Trusted_Connection=True;TrustServerCertificate=True;User ID=帳號;Password=密碼" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -NoOnConfiguring -UseDatabaseNames -NoPluralize -Force
//      若成功的話，會看到Build succeeded.字眼，並在Models資料夾裡看到dbStudentsContext.cs(描述資料庫)及tStudent.cs(描述資料表)

//1.2.3 在dbStudentsContext.cs裡撰寫連線到資料庫的程式
//      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//              => optionsBuilder.UseSqlServer("Data Source=伺服器位址;Database=資料庫名稱;Trusted_Connection=True;TrustServerCertificate=True;User ID=帳號;Password=密碼");

//1.2.4 在dbStudentsContext.cs裡撰寫一個空的建構子
//      public dbStudentsContext()
//{
//}


//2.製作自動生成的tStudent資料表的CRUD功能

//2.1 使用Scaffold方法讓Visual Studio自動建立出tStudent資料表的的CRUD功能
//    包含tStudentController及Index.cshtml、Create.cshtml、Edit.cshtml、Delete.cshtml、Details.cshtml等五個View的全部程式碼

//2.1.1 在Controllers資料夾上按右鍵→加入→控制器
//2.1.2 選擇「使用EntityFramework執行檢視的MVC控制器」→按下「加入」鈕
//2.1.3 在對話方塊中設定如下
//      模型類別: tStudent(MyModel_DBFirst.Models)
//      資料內容類別: dbStudentsContext(MyModel_DBFirst.Models)
//      勾選 產生檢視
//      勾選 參考指令碼程式庫
//      勾選 使用版面配置頁
//      控制器名稱使用預設即可(tStudentsController)
//      按下「新增」鈕
//2.1.4 此時Visual Studio會進行Scaffolding動作，將產出一個tStudentsController(會包含所有相關的Action)及五個View(Index.cshtml、Create.cshtml、Edit.cshtml、Delete.cshtml、Details.cshtml)的全部程式碼
//      ※備註說明※
//      Index.cshtml(List範本)
//      Create.cshtml(Create範本)
//      Edit.cshtml(Edit範本)
//      Delete.cshtml(Delete範本)
//      Details.cshtml(Details範本)

//2.2   修改tStudentsController內容
//2.2.1 撰寫建立DbContext物件的程式
//      dbStudentsContext _context=new dbStudentsContext();
//2.2.2 將原先既有的程式碼註解掉
//      private readonly dbStudentsContext _context;
//public tStudentsController(dbStudentsContext context)
//{
//    _context = context;
//}

//2.3   執行Index View進行CRUD功能測試

//※補充說明※
//使用Scaffold方法讓Visual Studio自動建立出的tStudentController，預設會使用「依賴注入(Dependency Injection)」的寫法
//不過一開始我們先不使用依賴注入的寫法，因此我們需修改如1.2.4及2.2等步驟的程式碼後才能正常執行

///////////////////////////////////////////////////////
/////3. 撰寫模型內容

//3.1 打開tStudent.cs檔案
//3.2 撰寫在View上顯示的欄位內容
//3.3 撰寫在表單上的欄位驗證規則(需using System.ComponentModel.DataAnnotations)
//    常用的驗證器 Required、StringLength、RegularExpression、Compare、EmailAddress、Range、DataType
//    Required:必填欄位
//    StringLength:資料字數
//    RegularExpression:資料格式
//    Compare:與其它欄位比較是否相等
//    EmailAddress:是否是E - mail格式
//    Range: 限制所填的範圍


///////////////////////////////////////////////////////
//4.製作手工打造的tStudent資料表的CRUD功能

//4.1   建立MyStudentsController
//4.1.1 在Controllers資料夾上按右鍵→加入→控制器
//4.1.2 選擇「MVC控制器 - 空白」
//4.1.3 輸入檔名MyStudentsController.cs
//4.1.4 撰寫建立DbContext物件的程式

//4.2   建立同步執行的Index Action
//4.2.1 撰寫Index Action程式碼
//4.2.2 建立Index View
//4.2.3 在Index Action內按右鍵→新增檢視→選擇「Razor檢視」→按下「加入」鈕
//4.2.4 在對話方塊中設定如下
//      檢視名稱: Index
//      範本:List
//      模型類別: tStudent(MyModel_DBFirst.Models)
//      資料內容類別: dbStudentsContext(MyModel_DBFirst.Models)
//      不勾選 建立成局部檢視
//      不勾選 參考指令碼程式庫
//      勾選 使用版面配置頁
//4.2.5 執行Index View測試
//4.2.6 修改介面上的文字，拿掉Details的超鏈結
//      ※可依自己的喜好修改View的顯示※

//4.3   建立同步執行的Create Action
//4.3.1 撰寫Create Action程式碼(需有兩個Create Action)
//4.3.2 建立Create View
//4.3.3 在Create Action內按右鍵→新增檢視→選擇「Razor檢視」→按下「加入」鈕
//4.3.4 在對話方塊中設定如下
//      檢視名稱: Index
//      範本:Create
//      模型類別: tStudent(MyModel_DBFirst.Models)
//      資料內容類別: dbStudentsContext(MyModel_DBFirst.Models)
//      不勾選 建立成局部檢視
//      勾選 參考指令碼程式庫
//      勾選 使用版面配置頁
//4.3.5 執行Create功能測試
//      ※可依自己的喜好修改View的顯示※
//4.3.6 加入Token驗證標籤

//4.4   建立同步執行的Edit Action
//4.4.1 撰寫Edit Action程式碼(需有兩個Edit Action)
//4.4.2 建立Edit View
//4.4.3 在Edit Action內按右鍵→新增檢視→選擇「Razor檢視」→按下「加入」鈕
//4.4.4 在對話方塊中設定如下
//      檢視名稱: Index
//      範本:Edit
//      模型類別: tStudent(MyModel_DBFirst.Models)
//      資料內容類別: dbStudentsContext(MyModel_DBFirst.Models)
//      不勾選 建立成局部檢視
//      勾選 參考指令碼程式庫
//      勾選 使用版面配置頁
//4.4.5 執行Edit功能測試
//      ※可依自己的喜好修改View的顯示※

//4.5   建立同步執行的Delete Action
//4.5.1 撰寫Delete Action程式碼
//4.5.2 將Index的Delete改為Form，以Post方式送出
//4.5.3 執行Delete功能測試
//※補充說明※
//這種寫法用不到Delete View，因此可以把Delete.cshtml刪除
//Delete的按鈕若使用超鏈結，將會有資安問題，使用者可直接在url給參數就能刪除資料


//5. 資料庫修改
//※尤於DB First是以反向工程利用資料庫寫成的程式碼，因此在資料庫有小幅變動時，則必須手動撰寫模型內容※

//5.1   在tStudent資料表中增加一個欄位
//5.1.1 在SSMS中執行下列DDL指令碼以修改tStudent資料表及，增加一個DeptID欄位
//alter table tStudent
//	    add DeptID varchar(2) not null default '01'
//  go
//5.1.2 在tStudent Class中增加一個屬性 public string DeptID { get; set; }
//5.1.3 視情況修改View
//5.1.4 執行測試

//5.2   在dbStudents資料庫中增加資料表
//5.2.1 在SSMS中執行下列DDL指令碼以建立Department資料表及與tStudnet的關聯
//////////////////////////////////////////////////////////
//create table Department(
//    DeptID varchar(2) primary key,
//    DeptName nvarchar(30) not null
//)
//go

//insert into Department values('01','資工系'),('02', '資管系'),('03', '工管系')
//go

//alter table tStudent
//	add foreign key(DeptID) references Department(DeptID) on delete no action on update no action
//go
//////////////////////////////////////////////////////////
//5.2.2 在Models資料夾中新增Department Class(Models資料夾上按右鍵→加入→類別)，內容如下
//public class Department
//{
//    [Key]
//    public string DeptID { get; set; }
//    public string DeptName { get; set; }
//    public List<tStudent> tStudents { get; set; }
//}
//5.2.3 修改tStudent Class以建立與Department的關聯，內容如下
//  [ForeignKey("Department")]
//public string DeptID { get; set; }
//public virtual Department Department { get; set; }

//5.2.4 在dbStudentsContext中加入Department的DbSet

//5.3   重新製作自動生成的tStudent資料表CRUD功能
//5.3.1 將原本的tStudentsControler及相關的View全數刪除
//5.3.2 在Controllers資料夾上按右鍵→加入→控制器
//5.3.3 選擇「使用EntityFramework執行檢視的MVC控制器」→按下「加入」鈕
//5.3.4 在對話方塊中設定如下
//      模型類別: tStudent(MyModel_DBFirst.Models)
//      資料內容類別: dbStudentsContext(MyModel_DBFirst.Models)
//      勾選 產生檢視
//      勾選 參考指令碼程式庫
//      勾選 使用版面配置頁
//      控制器名稱使用預設即可(tStudentsController)
//      按下「新增」鈕
//5.3.5 參考2 .2.1修改建立DbContext物件的程式
//5.3.6 測試

//※補充說明※
//※若資料庫的變動幅度較大，則建議重新執行Scaffold - DbContext指令重建整個模型※
//※不過若以Scaffold - DbContext重新建立模型，會將的DbContext及各個Class皆變回初始的程式碼，之前自己撰寫的部份會全部消失※
//※對於Controller及View來說，若不相重新Scaffold CRUD亦必須一個一個手動修改※

//5.4   視情況修改各個View有關Department的顯示

//5.5   手動修改MyStudentsController及相關的View
//5.5.1 修改 Index Action
//5.5.2 修改 Index View
//5.5.3 修改 Create Action
//5.5.4 修改 Create View
//5.5.5 修改 Edit Action
//5.5.6 修改 Edit View

//5.6 製作自動生成的Department資料表的CRUD功能
//5.6.1 在Controllers資料夾上按右鍵→加入→控制器
//5.6.2 選擇「使用EntityFramework執行檢視的MVC控制器」→按下「加入」鈕
//5.6.3 在對話方塊中設定如下
//      模型類別: Department(MyModel_DBFirst.Models)
//      資料內容類別: dbStudentsContext(MyModel_DBFirst.Models)
//      勾選 產生檢視
//      勾選 參考指令碼程式庫
//      勾選 使用版面配置頁
//      控制器名稱使用預設即可(DepartmentsController)
//      按下「新增」鈕
//5.6.4 參考2.2.1修改建立DbContext物件的程式
//5.6.5 測試

//5.7   編輯Layout選單，加入「科系管理」及「學生資料管理」


//5.8   使用者介面的運用技巧-View Model
//5.8.1 建立ViewModels資料夾(專案上按右鍵→加入→新增資料夾)
//5.8.2 在ViewModels資料夾新增VMtStudent類別(右鍵→加入→類別→輸入VMtStudent.cs→按下「新增」鈕)做為Model(這個Model只給View排版用因此稱作ViewModel)
//5.8.3 撰寫VMtStudent類別
//5.8.4 修改MyStudnetsController裡的Index Action
//5.8.5 修改Index View的排版方式
//5.8.6 測試
//※補充說明※
//View Model指的是專為View設計的Model，主要用於View的呈現或驗證規則(商業邏輯)

//5.9   網頁的狀態保留
//※說明:目前執行完新增或修改功能，導回Index Action時皆會呈現「資工系」的學生資料※
//※這是因為Index Action若沒給參數則會預設使用deptid="01"的資料，造成流程上的小問題※
//※因此需要修改Create、Edit與Delete的Action及View進行參數傳遞，以保留住網頁原本的狀態※
//5.9.1 修改Index View上Create的超鏈結進行參數傳遞
//5.9.2 修改Get Create Action進行參數傳遞
//5.9.3 修改Post Create Action進行參數傳遞
//5.9.4 修改Post Edit Action進行參數傳遞
//5.9.5 修改Post Delete Action進行參數傳遞
//5.9.6 測試


//6.將取得資料改為依賴注入(Dependency Injection)的寫法

//6.1   資料庫連線字串的改寫
//      ※目前我們將資料庫的連線字串寫在DbContext的類別檔(dbStudentsContext.cs)中，這是一種不安全的寫法※
//6.1.1 將連線字串寫在appsettings.json檔中
//6.1.2 將步驟1.2.3在dbStudentsContext中所寫的連線字串註解掉
//6.1.3 將步驟1.2.4在dbStudentsContext中所寫的空建構子註解掉(也可留著只是用不到)
//6.1.4 在Program.cs加入使用appsettings.json中的連線字串程式碼(這段必須寫法var builder這行後面)

//6.2   修正tStudentsController建立DbContext物件的寫法
//6.2.1 將步驟2.2.1所寫的建立DbContext物件的程式註解
//6.2.2 將步驟2.2.2所註解掉的程式取消註解(這裡的寫法是scaffold預設的依賴注入寫法)
//6.2.3 參照tStudentsController，修改MyStudentsController中建立DbContext物件的程式為依賴注入寫法

//※補充說明※
//依賴注入(Dependency Injection)是物件導向程式設計撰寫時的一種技巧
//其利用控制反轉(IoC)的概念，將new主動建立物建的寫法反轉為被動地接受物件
//物件的生命週期控制權則在DI Container手上而不是使用物件的程式
//這個寫法的優點是解除物件之間的耦合，有利於程式維護、單元測試等
