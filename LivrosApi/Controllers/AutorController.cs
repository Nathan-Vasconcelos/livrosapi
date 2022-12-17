using AutoMapper;
using LivrosApi.Data;
using LivrosApi.Data.AutorDto;
using LivrosApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AutorController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AutorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CriarAutor(CreateAutorDto autorDto)
        {
            //criar novo autor
            Autor autor = _mapper.Map<Autor>(autorDto);
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarAutorPorId), new {Id = autor.Id}, autor);
        }

        [HttpGet]
        public IActionResult RecuperaAutores()
        {
            List<ReadAutorDto> autoresDto = _mapper.Map<List<ReadAutorDto>>(_context.Autores.ToList());
            return Ok(autoresDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarAutorPorId(int id)
        {
            Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            ReadAutorDto autorDto = _mapper.Map<ReadAutorDto>(autor);
            return Ok(autorDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarAutor(int id, [FromBody] UpdateAutorDto autorDto)
        {
            Autor autor = _context.Autores.FirstOrDefault(autor => autor.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            _mapper.Map(autorDto, autor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
