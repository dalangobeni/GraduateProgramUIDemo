using AutoMapper;
using Backend.Domain;

namespace Backend.Models.LibraryModel
{
	public class AutoMapper : Profile
	{
		public AutoMapper()
		{
			CreateMap<LibraryDto, Library>()
				.ForMember(c => c.Id, opt => opt.Ignore())
				.ForMember(c => c.Shelve, opt => opt.MapFrom(a => a.Shelve))
				.ForMember(c => c.Librarian, opt => opt.MapFrom(a => a.LibrarianId))
				.ForMember(c => c.IsPopular, opt => opt.MapFrom(a => a.IsPopular))
				.ForMember(c => c.TimeOpen, opt => opt.MapFrom(a => a.TimeOpen))
				.ForMember(c => c.Book, opt => opt.MapFrom(a => a.IsPopular))
				.ReverseMap();

			CreateMap<LibraryDisplayDto, Library>()
				.ForMember(c => c.Id, opt => opt.MapFrom(a => a.Id))
				.ForMember(c => c.Shelve, opt => opt.MapFrom(a => a.Shelve))
				.ForMember(c => c.Librarian, opt => opt.MapFrom(a => a.Librarian))
				.ForMember(c => c.IsPopular, opt => opt.MapFrom(a => a.IsPopular))
				.ForMember(c => c.TimeOpen, opt => opt.MapFrom(a => a.TimeOpen))
				.ForMember(c => c.Book, opt => opt.MapFrom(a => a.Book))
				.ReverseMap();
		}
	}
}
