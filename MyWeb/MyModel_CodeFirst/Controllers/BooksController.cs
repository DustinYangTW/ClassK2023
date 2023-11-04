using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

namespace MyModel_CodeFirst.Controllers
{
    public class BooksController : Controller
    {
        private readonly GuestBookContext _context;

        public BooksController(GuestBookContext context)
        {
            _context = context;
        }

        //2.3.2 在BooksController內增加讀取照片的方法
        public async Task<FileContentResult> GetImage(long gid)
        {
            var book = await _context.Book.FindAsync(gid);

            if (book != null)
            {
                return File(book.Photo, book.ImageType);
            }

            return null;
        }



        // GET: Books
        public async Task<IActionResult> Index()
        {
            //2.2.1 改寫Index Action的內容，將留言依新到舊排序
            var bookList = await _context.Book.OrderByDescending(b => b.GId).ToListAsync();

            return View();
        }


        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.GId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Book == null)
            {
                return Problem("這裡有一些些小問題發生哦....");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(long id)
        {
            return _context.Book.Any(e => e.GId == id);
        }
    }
}
