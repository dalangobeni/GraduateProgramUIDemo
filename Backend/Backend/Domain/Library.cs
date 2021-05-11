using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain
{
	public class Library
	{
		public Guid Id { get; set; }
		public string Shelve { get; set; }
		public Librarian Librarian { get; set; }
		public string Book { get; set; }
		public DateTime TimeOpen { get; set; }
		public bool IsPopular { get; set; }
	}
}
