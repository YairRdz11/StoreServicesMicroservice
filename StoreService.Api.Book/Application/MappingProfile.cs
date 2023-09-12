using AutoMapper;
using StoreService.Api.Book.Models;

namespace StoreService.Api.Book.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Library, BookDTO>();
        }
    }
}
