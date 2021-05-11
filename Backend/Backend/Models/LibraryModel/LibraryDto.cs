using Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.LibraryModel
{
	public class LibraryDto
	{
		public Guid Id { get; set; }
		public string Shelve { get; set; }
		public Guid LibrarianId { get; set; }
		public string Book { get; set; }
		public DateTime TimeOpen { get; set; }
		public bool IsPopular { get; set; }
	}

	public class LibraryDisplayDto
	{
		public Guid Id { get; set; }
		public string Shelve { get; set; }
		public Librarian Librarian { get; set; }
		public string Book { get; set; }
		public DateTime TimeOpen { get; set; }
		public bool IsPopular { get; set; }
	}
}

