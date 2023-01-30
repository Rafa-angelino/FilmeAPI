using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Services;

namespace UsuarioApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto dto)
        {
            Result resultado = _cadastroService.CadastraUsuario(dto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
