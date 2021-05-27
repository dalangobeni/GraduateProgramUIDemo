using AutoMapper;
using Backend.Data;
using Backend.Domain;
using Backend.Services.LibrarianServices;
using System;
using System.Threading.Tasks;

namespace Backend.Models.LibraryModel
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<LibraryDto, Library>()
				.ForMember(c => c.Id, opt => opt.Ignore())
				.ForMember(c => c.Shelve, opt => opt.MapFrom(a => a.Shelve))
				//.ForMember(c => c.Librarian, opt => opt.MapFrom(a => GetLibrarian(a.LibrarianId)))
				.ForMember(c => c.IsPopular, opt => opt.MapFrom(a => a.IsPopular))
				.ForMember(c => c.TimeOpen, opt => opt.MapFrom(a => a.TimeOpen))
				.ForMember(c => c.Book, opt => opt.MapFrom(a => a.IsPopular));

			CreateMap<Library, LibraryDto>()
				.ForMember(c => c.LibrarianId, opt => opt.MapFrom(a => a.Librarian.Id));

			CreateMap<Library, LibraryDisplayDto>()
				.ForMember(c => c.Id, opt => opt.MapFrom(a => a.Id))
				.ForMember(c => c.Shelve, opt => opt.MapFrom(a => a.Shelve))
				.ForMember(c => c.Librarian, opt => opt.MapFrom(a => a.Librarian))
				.ForMember(c => c.IsPopular, opt => opt.MapFrom(a => a.IsPopular))
				.ForMember(c => c.TimeOpen, opt => opt.MapFrom(a => a.TimeOpen))
				.ForMember(c => c.Book, opt => opt.MapFrom(a => a.Book));
		}

		protected static async Task<Librarian> GetLibrarian(Guid librarianId)
		{
			var librarianService = Abp.Dependency.IocManager.Instance.Resolve<ILibrarianService>();

			var librarianEntity = await librarianService.GetLibrarian(librarianId);

			return librarianEntity;
		}
	}
}
