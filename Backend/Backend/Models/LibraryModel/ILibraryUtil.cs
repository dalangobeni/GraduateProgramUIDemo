using Backend.Domain;
using System;
using System.Threading.Tasks;

namespace Backend.Models.LibraryModel
{
	public interface ILibraryUtil
	{
		Task<Librarian> GetLibrarian(Guid librarianId);
	}
}
