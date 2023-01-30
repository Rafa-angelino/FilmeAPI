using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos.Gerente;
using FilmeAPI.Data.Dtos.Sessao;
using FilmeAPI.Models;
using FilmeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
             _sessaoService = sessaoService;
        }

        [HttpPost]

        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(dto);
            
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readDto.Id }, readDto);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperaSessaoPorId(id);
            if(readDto != null) return Ok(readDto);
            
            return NotFound(); ;
        }
    }
}
