using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos.Endereco;
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
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;


        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.AdicionaEndereco(enderecoDto);
            
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]

        public IActionResult RecuperaEndereco()
        {
            List<ReadEnderecoDto> readDto = _enderecoService.RecuperaEndereco();
            if (readDto == null) return null;
            return Ok(readDto);

        }

        [HttpGet("{id}")]

        public IActionResult RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDto readDto = _enderecoService.RecuperaEnderecosPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _enderecoService.AtualizaEndereco(id, enderecoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteEndereco(int id)
        {
            Result resultado = _enderecoService.DeletaEndereco(id);
            if(resultado.IsFailed) return NotFound();   
            return NoContent();
        }

    }
}
