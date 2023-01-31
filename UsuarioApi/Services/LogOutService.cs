using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;

namespace UsuarioApi.Services
{
    public class LogOutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogOutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogaUsuario()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("LogOut Falhou");
        }
    }
}
