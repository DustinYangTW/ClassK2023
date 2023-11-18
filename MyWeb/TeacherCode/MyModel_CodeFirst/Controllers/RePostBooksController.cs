using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;
using NuGet.Packaging.Signing;

namespace MyModel_CodeFirst.Controllers
{
    public class RePostBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public RePostBooksController(GuestBookContext context)
        {
            _context = context;
        }

     

        // GET: RePostBooks/Create
        public IActionResult Create(long id)
        {
            //ViewData["GId"] = new SelectList(_context.Book, "GId", "Author");

            ViewData["GId"] = id;

            return View();
        }

        // POST: RePostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RId,Description,Author,TimeStamp,GId")] ReBook reBook)
        {
            //3.5.9 修改RePostBooksController中的Create Action，使其可處理JSON資料

            reBook.TimeStamp = DateTime.Now;


            if (ModelState.IsValid)
            {
                _context.Add(reBook);
                await _context.SaveChangesAsync();

                //3.5.9 修改RePostBooksController中的Create Action，使其可處理JSON資料
                var data = new
                {
                    rid = reBook.RId,
                    author = reBook.Author,
                    description = reBook.Description,
                    timestamp = reBook.TimeStamp.ToString("yyyy/MM/dd HH:mm"),
                    gid = reBook.GId
                };


                return Json(data);
                //return RedirectToAction(nameof(Index));
            }


            ViewData["GId"] = reBook.GId;

            return Json(reBook);
            //return View(reBook);
        }

        
    }
}
