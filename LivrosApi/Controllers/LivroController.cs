using AutoMapper;
using LivrosApi.Data;
using LivrosApi.Data.LivroDto;
using LivrosApi.Models;
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

        public LivroController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarLivro([FromBody] CreateLivroDto livroDto)
        {
            //Adicionar um livro
            Livro livro = _mapper.Map<Livro>(livroDto);
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarLivroPorId), new { Id = livro.Id }, livro);
        }

        [HttpGet]
        public IActionResult RecuperarLivros()
        {
            //buscar todos os livros
            List<ReadLivroDto> livrosDto = _mapper.Map<List<ReadLivroDto>>(_context.Livros.ToList());
            return Ok(livrosDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarLivroPorId(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);
            return Ok(livroDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarLivro(int id, [FromBody] UpdateLivroDto livroDto)
        {
            //editar livro
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            _mapper.Map(livroDto, livro);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverLivro(int id)
        {
            //remover livro
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            _context.Remove(livro);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
