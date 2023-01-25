using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.DTO_S;
using FilmeAPI.Data.DTO_S.Cinema;
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

    public class CinemaController : ControllerBase
    {
        private  CinemaService _cinemaService;  


        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService; 
        }

        [HttpPost]

        public IActionResult AdicionaCinema([FromBody]  CreateCinemaDto cinemaDto )
        {
            ReadCinemaDto readDto = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDofilme)
        {
            List<ReadCinemaDto> readDto =_cinemaService.RecuperaCinemas(nomeDofilme);
           if(readDto != null) return Ok(readDto);
            return NotFound();


        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperaCinemaPorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]

        public IActionResult AtualizaCinemas(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinemas(id, cinemaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);
            if(resultado.IsFailed) return NotFound();   
            return NoContent();
        }
    }
}
