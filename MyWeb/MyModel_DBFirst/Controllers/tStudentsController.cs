using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_DBFirst.Models;

namespace MyModel_DBFirst.Controllers
{
    public class tStudentsController : Controller
    {
        //private readonly dbStudentsContext _context;

        //public tStudentsController(dbStudentsContext context)
        //{
        //    _context = context;
        //}

        dbStudentsContext _context = new dbStudentsContext();

        // GET: tStudents
        public async Task<IActionResult> Index()
        {
            var dbStudentsContext = _context.tStudent.Include(t => t.Department);
            return View(await dbStudentsContext.ToListAsync());
        }

        // GET: tStudents/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.tStudent == null)
            {
                return NotFound();
            }

            var tStudent = await _context.tStudent
                .Include(t => t.Department)
                .FirstOrDefaultAsync(m => m.fStuId == id);
            if (tStudent == null)
            {
                return NotFound();
            }

            return View(tStudent);
        }

        // GET: tStudents/Create
        public IActionResult Create()
        {
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptID");
            return View();
        }

        // POST: tStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fStuId,fName,fEmail,fScore,DeptID")] tStudent tStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptID", tStudent.DeptID);
            return View(tStudent);
        }

        // GET: tStudents/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.tStudent == null)
            {
                return NotFound();
            }

            var tStudent = await _context.tStudent.FindAsync(id);
            if (tStudent == null)
            {
                return NotFound();
            }
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptID", tStudent.DeptID);
            return View(tStudent);
        }

        // POST: tStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("fStuId,fName,fEmail,fScore,DeptID")] tStudent tStudent)
        {
            if (id != tStudent.fStuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tStudentExists(tStudent.fStuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptID", tStudent.DeptID);
            return View(tStudent);
        }

        // GET: tStudents/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.tStudent == null)
            {
                return NotFound();
            }

            var tStudent = await _context.tStudent
                .Include(t => t.Department)
                .FirstOrDefaultAsync(m => m.fStuId == id);
            if (tStudent == null)
            {
                return NotFound();
            }

            return View(tStudent);
        }

        // POST: tStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.tStudent == null)
            {
                return Problem("Entity set 'dbStudentsContext.tStudent'  is null.");
            }
            var tStudent = await _context.tStudent.FindAsync(id);
            if (tStudent != null)
            {
                _context.tStudent.Remove(tStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tStudentExists(string id)
        {
          return _context.tStudent.Any(e => e.fStuId == id);
        }
    }
}
