using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyModel_DBFirst.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyModel_DBFirst.ViewModels;

namespace MyModel_DBFirst.Controllers
{
    public class MyStudentsController : Controller
    {
        //4.1.4 撰寫建立DbContext物件的程式
        dbStudentsContext db = new dbStudentsContext();


        public IActionResult Index(string deptid="01")
        {
            //4.2.1 撰寫Index Action程式碼
            //SQL
            //select * from tStudent

            //Linq
            //var result = from s in db.tStudent
            //             select s;

            //5.5.1 修改 Index Action
            //var result = db.tStudent.ToList();
            //var result = db.tStudent.Include(s=>s.Department);


            //5.8.4 修改MyStudnetsController裡的Index Action
            VMtStudent result = new VMtStudent()
            {
                department=db.Department.ToList(),
                student=db.tStudent.Where(s=>s.DeptID== deptid).ToList()
            };

            ViewData["DeptID"] = deptid;
            ViewData["DeptName"] = db.Department.Find(deptid).DeptName;

            return View(result);
        }


        //4.3.1 撰寫Create Action程式碼(需有兩個Create Action)
        public IActionResult Create(string deptid)
        {
            ViewData["Today"] = DateTime.Now;

            //5.5.3 修改 Create Action
            ViewData["Department"] = new SelectList(db.Department, "DeptID", "DeptName");
            
            ViewData["DeptID"] = deptid;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //4.3.6 加入Token驗證標籤
        public IActionResult Create(tStudent tStudent)
        {

            //檢查學號(PK)有沒有重複
            //select * from tStudent where fStuId=@tStudent.fStuId

            var result = db.tStudent.Find(tStudent.fStuId);
            if (result != null)
            {
                ViewData["ErrMsg"] = "學號重複";
                return View(tStudent);
            }

            if (ModelState.IsValid)
            {
                db.Add(tStudent);
                db.SaveChanges();

                return RedirectToAction("Index", new { deptid= tStudent .DeptID});
            }

            return View(tStudent);
        }


        //4.4.1 撰寫Edit Action程式碼(需有兩個Edit Action)
        public IActionResult Edit(string id)
        {

            if (id == null)
            {
                return NotFound();
            }



            //seelct * from tStudent where fStuId=@id
            //var tStudent = db.tStudent.Where(s=>s.fStuId==id).FirstOrDefault();

            var tStudent = db.tStudent.Find(id);

            if (tStudent == null)
            {
                return NotFound();
            }

            //5.5.5 修改 Edit Action
            ViewData["Department"] = new SelectList(db.Department, "DeptID", "DeptName");

            return View(tStudent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(tStudent tStudent, string id)
        {
            if (id != tStudent.fStuId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                db.Update(tStudent);
                db.SaveChanges();

                return RedirectToAction("Index", new { deptid = tStudent.DeptID });
            }

            return View(tStudent);
        }

        //4.5.1 撰寫Delete Action程式碼
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var tStudent = db.tStudent.Find(id);


            db.Remove(tStudent);
            db.SaveChanges();

            return RedirectToAction("Index", new { deptid = tStudent.DeptID });

        }


    }
}
