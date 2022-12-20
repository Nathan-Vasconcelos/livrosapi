using AutoMapper;
using FluentResults;
using LivrosApi.Data;
using LivrosApi.Data.CategoriaDto;
using LivrosApi.Models;
using LivrosApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private CategoriaService _service;

        public CategoriaController(AppDbContext context, IMapper mapper, CategoriaService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            ReadCategoriaDto readDto = _service.AdicionarCategoria(categoriaDto);
            return CreatedAtAction(nameof(RecuperarCategoriaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarCategorias()
        {
            List<ReadCategoriaDto> categoriasDto = _service.RecuperarCategorias();
            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCategoriaPorId(int id)
        {
            ReadCategoriaDto categoriaDto = _service.RecuperarCategoriaPorId(id);
            if (categoriaDto == null) return NotFound();
            return Ok(categoriaDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
        {
            Result resultado = _service.EditarCategoria(id, categoriaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
