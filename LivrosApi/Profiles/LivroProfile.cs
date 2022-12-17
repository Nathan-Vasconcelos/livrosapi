using AutoMapper;
using LivrosApi.Data.LivroDto;
using LivrosApi.Models;

namespace LivrosApi.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            //mapear
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<Livro, ReadLivroDto>();
            CreateMap<UpdateLivroDto, Livro>();
        }
    }
}
