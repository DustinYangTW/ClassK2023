using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_DBFirst.Models;

namespace MyModel_DBFirst.Controllers
{
    public class MyStudentsController : Controller
    {
        //4.1.4 撰寫建立DbContext物件的程式
        dbStudentsContext db = new dbStudentsContext();


        public IActionResult Index()
        {
            //4.2.1 撰寫Index Action程式碼
            //SQL
            //select * from tStudent

            //Linq
            //var result = from s in db.tStudent
            //             select s;

            //var result = db.tStudent.ToList();
            var result = db.tStudent.Include(s => s.Department);

            return View(result);
        }


        //4.3.1 撰寫Create Action程式碼(需有兩個Create Action)
        public IActionResult Create()
        {
            ViewData["Today"] = DateTime.Now;

            //5.5.3 修改Create Action
            ViewData["Department"] = new SelectList(db.Department,"DeptID","DeptName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //4.3.6 加入Token驗證標籤
        public IActionResult Create(tStudent tStudent)
        {

            //檢查學號有沒有重複
            if(db.tStudent.Any(x => x.fStuId == tStudent.fStuId))
            {
                ViewData["ErrorMsg"] = "學號重複";
                return View(tStudent);
            }

            if (ModelState.IsValid)
            {
                db.Add(tStudent);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tStudent);
        }



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

            ViewData["Department"] = new SelectList(db.Department, "DeptID", "DeptName");
            return View(tStudent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //4.3.6 加入Token驗證標籤
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
                ViewData["Department"] = new SelectList(db.Department, "DeptID", "DeptName");
                return RedirectToAction("Index");
            }

            return View(tStudent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //4.3.6 加入Token驗證標籤
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //seelct * from tStudent where fStuId=@id
            //var tStudent = db.tStudent.Where(s=>s.fStuId==id).FirstOrDefault();

            var tStudent = db.tStudent.Find(id);

            db.Remove(tStudent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
