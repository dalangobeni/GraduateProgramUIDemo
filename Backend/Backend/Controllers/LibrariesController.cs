using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Domain;
using Backend.Models.LibraryModel;
using AutoMapper;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public LibrariesController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Libraries
        [HttpGet]
        public IEnumerable<Library> GetAllLibraries()
        {
            return _context.Library;
        }

        // GET: api/Libraries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibrary([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var library = await _context.Library.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }

        // PUT: api/Libraries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibrary([FromRoute] Guid id, [FromBody] Library library)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != library.Id)
            {
                return BadRequest();
            }

            _context.Entry(library).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(id))
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

        // POST: api/Libraries
        [HttpPost]
        public async Task<ActionResult<LibraryDisplayDto>> CreateNewLibrary([FromBody] LibraryDto library)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            library.Book += "Authur: Book Writer";

            var libraryEntity = _mapper.Map<Library>(library);

           var librarySavedEntity = _context.Library.Add(libraryEntity);
            await _context.SaveChangesAsync();


            return _mapper.Map<LibraryDisplayDto>(librarySavedEntity);
        }

        // DELETE: api/Libraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var library = await _context.Library.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            _context.Library.Remove(library);
            await _context.SaveChangesAsync();

            return Ok(library);
        }

        private bool LibraryExists(Guid id)
        {
            return _context.Library.Any(e => e.Id == id);
        }
    }
}