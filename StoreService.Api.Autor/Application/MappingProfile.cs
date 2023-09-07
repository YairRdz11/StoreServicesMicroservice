using AutoMapper;
using StoreService.Api.Autor.Models;

namespace StoreService.Api.Autor.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorBook, AutorDTO>();
        }
    }
}
