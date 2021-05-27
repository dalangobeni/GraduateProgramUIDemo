using Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.LibrarianServices
{
	public interface ILibrarianService
	{
		Task<Librarian> GetLibrarian(Guid librarianId);
	}
}
