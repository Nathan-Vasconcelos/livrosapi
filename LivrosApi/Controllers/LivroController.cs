using AutoMapper;
using Castle.Core.Internal;
using FluentResults;
using LivrosApi.Data;
using LivrosApi.Data.LivroDto;
using LivrosApi.Models;
using LivrosApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivroController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private LivroService _service;

        public LivroController(AppDbContext context, IMapper mapper, LivroService livroService)
        {
            _context = context;
            _mapper = mapper;
            _service = livroService;
        }

        [HttpPost]
        public IActionResult AdicionarLivro([FromBody] CreateLivroDto livroDto)
        {
            ReadLivroDto readDto = _service.AdicionarLivro(livroDto);
            return CreatedAtAction(nameof(RecuperarLivroPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarLivros([FromQuery] string? autor = null)
        {
            List<ReadLivroDto> livrosDto = _service.RecuperarLivros(autor);
            if (livrosDto == null) return NotFound();
            return Ok(livrosDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarLivroPorId(int id)
        {
            ReadLivroDto livroDto = _service.RecuperarLivroPorId(id);
            if (livroDto == null) return NotFound();
            return Ok(livroDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarLivro(int id, [FromBody] UpdateLivroDto livroDto)
        {
            Result resultado = _service.EditarLivro(id, livroDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverLivro(int id)
        {
            Result resultado = _service.RemoverLivro(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
