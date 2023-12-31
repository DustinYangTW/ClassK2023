﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

namespace MyModel_CodeFirst.Controllers
{
    public class PostBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public PostBooksController(GuestBookContext context)
        {
            _context = context;
        }

        // GET: PostBooks
        public async Task<IActionResult> Index()
        {
            var books = await _context.Book.OrderByDescending(b => b.TimeStamp).ToListAsync();
              return View(books);
        }

        // GET: PostBooks/Details/5
        //3.2.3 將PostBooksController中Details Action改名為Display(View也要改名字)
        public async Task<IActionResult> Display(long? id)
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

        // GET: PostBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, IFormFile uploadFile)
        {
            //檔案處理
            if (uploadFile != null)
            {
                if (uploadFile.ContentType == "image/jpeg" || uploadFile.ContentType == "image/png")
                {
                    var memoryStream=new MemoryStream();

                    uploadFile.CopyTo(memoryStream);
                    book.Photo = memoryStream.ToArray();
                    book.ImageType = uploadFile.ContentType;
                }
            }

            book.TimeStamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        private bool BookExists(long id)
        {
          return _context.Book.Any(e => e.GId == id);
        }
    }
}
