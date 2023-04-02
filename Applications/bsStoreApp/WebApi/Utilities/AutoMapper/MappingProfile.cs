using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDtoForUpdate>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookDtoForInsertion, Book>().ReverseMap();
        }
    }
}
