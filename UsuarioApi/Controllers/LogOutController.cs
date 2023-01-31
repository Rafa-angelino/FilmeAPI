using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Services;

namespace UsuarioApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogOutController : ControllerBase
    {
        private LogOutService _logOutService;

        public LogOutController(LogOutService logOutService)
        {
            _logOutService = logOutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result resultado = _logOutService.DeslogaUsuario();
            if(resultado.IsFailed) return Unauthorized();

            return Ok(resultado.Successes);
        }
    }
}
