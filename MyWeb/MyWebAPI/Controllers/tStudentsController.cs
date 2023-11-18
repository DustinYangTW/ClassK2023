using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tStudentsController : ControllerBase
    {
        private readonly dbStudentsContext _context;

        public tStudentsController(dbStudentsContext context)
        {
            _context = context;
        }

        // GET: api/tStudents
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<tStudent>>> GettStudents(string id)
        {
          if (_context.tStudent == null)
          {
              return NotFound();
          }
            return await _context.tStudent.Where(s=>s.DeptID==id).ToListAsync();
        }

        // GET: api/tStudents/Student/112003
        [HttpGet("Student/{id}")]
        public async Task<ActionResult<tStudent>> GettStudent(string id)
        {
          if (_context.tStudent == null)
          {
              return NotFound();
          }
            var tStudent = await _context.tStudent.FindAsync(id);

            if (tStudent == null)
            {
                return NotFound();
            }

            return tStudent;
        }

        // PUT: api/tStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttStudent(string id, tStudent tStudent)
        {
            if (id != tStudent.fStuId)
            {
                return BadRequest();
            }

            _context.Entry(tStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/tStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tStudent>> PosttStudent(tStudent tStudent)
        {
          if (_context.tStudent == null)
          {
              return Problem("Entity set 'dbStudentsContext.tStudent'  is null.");
          }
            _context.tStudent.Add(tStudent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tStudentExists(tStudent.fStuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GettStudent", new { id = tStudent.fStuId }, tStudent);
        }

        // DELETE: api/tStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetStudent(string id)
        {
            if (_context.tStudent == null)
            {
                return NotFound();
            }
            var tStudent = await _context.tStudent.FindAsync(id);
            if (tStudent == null)
            {
                return NotFound();
            }

            _context.tStudent.Remove(tStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tStudentExists(string id)
        {
            return (_context.tStudent?.Any(e => e.fStuId == id)).GetValueOrDefault();
        }
    }
}
