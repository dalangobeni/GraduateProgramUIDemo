using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Domain;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariansController : ControllerBase
    {
        private readonly SchoolContext _context;

        public LibrariansController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Librarians
        [HttpGet]
        public IEnumerable<Librarian> GetLibrarian()
        {
            return _context.Librarian;
        }

        // GET: api/Librarians/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibrarian([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var librarian = await _context.Librarian.FindAsync(id);

            if (librarian == null)
            {
                return NotFound();
            }

            return Ok(librarian);
        }

        // PUT: api/Librarians/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrarian([FromRoute] Guid id, [FromBody] Librarian librarian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != librarian.Id)
            {
                return BadRequest();
            }

            _context.Entry(librarian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrarianExists(id))
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

        // POST: api/Librarians
        [HttpPost]
        public async Task<IActionResult> PostLibrarian([FromBody] Librarian librarian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Librarian.Add(librarian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrarian", new { id = librarian.Id }, librarian);
        }

        // DELETE: api/Librarians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrarian([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var librarian = await _context.Librarian.FindAsync(id);
            if (librarian == null)
            {
                return NotFound();
            }

            _context.Librarian.Remove(librarian);
            await _context.SaveChangesAsync();

            return Ok(librarian);
        }

        private bool LibrarianExists(Guid id)
        {
            return _context.Librarian.Any(e => e.Id == id);
        }
    }
}