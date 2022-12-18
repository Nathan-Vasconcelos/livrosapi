using AutoMapper;
using Castle.Core.Internal;
using FluentResults;
using LivrosApi.Data;
using LivrosApi.Data.LivroDto;
using LivrosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LivrosApi.Services
{
    public class LivroService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public LivroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadLivroDto AdicionarLivro(CreateLivroDto livroDto)
        {
            Livro livro = _mapper.Map<Livro>(livroDto);
            _context.Livros.Add(livro);
            _context.SaveChanges();

            ReadLivroDto readDto = _mapper.Map<ReadLivroDto>(livro);
            return readDto;
        }

        public List<ReadLivroDto> RecuperarLivros(string? autor = null)
        {
            List<ReadLivroDto> livrosDto;
            if (autor == null)
            {
                livrosDto = _mapper.Map<List<ReadLivroDto>>(_context.Livros.ToList());
                return livrosDto;
            }
            else
            {
                livrosDto = _mapper.Map<List<ReadLivroDto>>(_context.Livros.
                Where(livrosDto => livrosDto.Autor.Nome == autor).ToList());

                if (livrosDto.IsNullOrEmpty())
                {
                    return null;
                }
            }
            return livrosDto;
        }

        public ReadLivroDto RecuperarLivroPorId(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return null;
            }

            ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);
            return livroDto;
        }

        public Result EditarLivro(int id, UpdateLivroDto livroDto)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return Result.Fail("Livro não encontrdo");
            }
            _mapper.Map(livroDto, livro);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result RemoverLivro(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return Result.Fail("Livro não encontrdo");
            }
            _context.Remove(livro);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
