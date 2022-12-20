using AutoMapper;
using FluentResults;
using LivrosApi.Data;
using LivrosApi.Data.CategoriaDto;
using LivrosApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LivrosApi.Services
{
    public class CategoriaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CategoriaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCategoriaDto AdicionarCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            ReadCategoriaDto readDto = _mapper.Map<ReadCategoriaDto>(categoria);
            return readDto;
        }

        public List<ReadCategoriaDto> RecuperarCategorias()
        {
            List<ReadCategoriaDto> categoriasDto = _mapper.Map<List<ReadCategoriaDto>>(_context.Categorias.ToList());
            return categoriasDto;
        }

        public ReadCategoriaDto RecuperarCategoriaPorId(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return null;
            }
            ReadCategoriaDto categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
            return categoriaDto;
        }

        public Result EditarCategoria(int id, UpdateCategoriaDto categoriaDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return Result.Fail("Categoria não encontrada");
            }
            _mapper.Map(categoriaDto, categoria);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
