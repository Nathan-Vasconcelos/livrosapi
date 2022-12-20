using AutoMapper;
using FluentResults;
using LivrosApi.Data;
using LivrosApi.Data.AutorDto;
using LivrosApi.Models;
using LivrosApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AutorController : ControllerBase
    {
        private AutorService _service;

        public AutorController(AutorService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarAutor(CreateAutorDto autorDto)
        {
            ReadAutorDto readDto = _service.CriarAutor(autorDto);
            return CreatedAtAction(nameof(RecuperarAutorPorId), new {Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarAutores()
        {
            List<ReadAutorDto> autoresDto = _service.RecuperarAutores();
            return Ok(autoresDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarAutorPorId(int id)
        {
            ReadAutorDto readDto = _service.RecuperarAutorPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarAutor(int id, [FromBody] UpdateAutorDto autorDto)
        {
            Result resultado = _service.EditarAutor(id, autorDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
