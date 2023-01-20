using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos.Gerente;
using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;  
        }

        [HttpPost]

        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto dto)
        {
            var gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente); 
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerente()
        {
            return _context.Gerentes;
        }

        [HttpGet("{id}")]

        public IActionResult RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente != null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);  
                return Ok(gerenteDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null) return NotFound();

            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
