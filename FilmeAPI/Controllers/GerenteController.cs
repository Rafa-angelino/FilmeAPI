using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos.Gerente;
using FilmeAPI.Models;
using FilmeAPI.Services;
using FluentResults;
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
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
             _gerenteService = gerenteService;
        }

        [HttpPost]

        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaGerente()
        {
            List<ReadGerenteDto> readDto = _gerenteService.RecuperaGerente();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]

        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperaGerentePorId(id);
            if(readDto != null) return Ok(readDto); 
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _gerenteService.DeletaGerente(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }


    }
}
