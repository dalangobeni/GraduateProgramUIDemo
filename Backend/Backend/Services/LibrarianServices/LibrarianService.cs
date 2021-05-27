using Backend.Data;
using Backend.Domain;
using System;
using System.Threading.Tasks;

namespace Backend.Services.LibrarianServices
{
	public class LibrarianService : ILibrarianService
	{
		private readonly SchoolContext _context;

		public LibrarianService(SchoolContext context)
		{
			_context = context;
		}

		public async Task<Librarian> GetLibrarian(Guid librarianId)
		{
			var librarianEntity = await _context.Librarian.FindAsync(librarianId);

			return librarianEntity;
		}
	}
}
