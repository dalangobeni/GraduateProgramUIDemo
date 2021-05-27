using Abp.Dependency;
using Abp.Domain.Repositories;
using Backend.Data;
using Backend.Domain;
using Backend.Services.LibrarianServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.LibraryModel
{
	public static class LibraryUtil
	{
		private static ILibrarianService _librarianService;
		static LibraryUtil()
		{
			_librarianService = IocManager.Instance.Resolve<ILibrarianService>();
		}

		public static async Task<Librarian> GetLibrarian(Guid librarianId)
		{
			var librarianEntity = await _librarianService.GetLibrarian(librarianId);

			return librarianEntity;
		}
	}
}
