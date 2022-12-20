using AutoMapper;
using FluentResults;
using LivrosApi.Data;
using LivrosApi.Data.AutorDto;
using LivrosApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LivrosApi.Services
{
    public class AutorService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AutorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAutorDto CriarAutor(CreateAutorDto autorDto)
        {
            Autor autor = _mapper.Map<Autor>(autorDto);
            _context.Autores.Add(autor);
            _context.SaveChanges();
            ReadAutorDto readDto = _mapper.Map<ReadAutorDto>(autor);
            return readDto;
        }

        public List<ReadAutorDto> RecuperarAutores()
        {
            List<ReadAutorDto> autoresDto = _mapper.Map<List<ReadAutorDto>>(_context.Autores.ToList());
            return autoresDto;
        }

        public ReadAutorDto RecuperarAutorPorId(int id)
        {
            Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);
            if (autor == null)
            {
                return null;
            }
            ReadAutorDto autorDto = _mapper.Map<ReadAutorDto>(autor);
            return autorDto;
        }

        public Result EditarAutor(int id, UpdateAutorDto autorDto)
        {
            Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);
            if (autor == null)
            {
                return Result.Fail("Autor não encontrado");
            }
            _mapper.Map(autorDto, autor);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
