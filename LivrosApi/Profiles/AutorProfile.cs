using AutoMapper;
using LivrosApi.Data.AutorDto;
using LivrosApi.Models;

namespace LivrosApi.Profiles
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<CreateAutorDto, Autor>();
            CreateMap<Autor, ReadAutorDto>();
            CreateMap<UpdateAutorDto, Autor>();
        }
    }
}
