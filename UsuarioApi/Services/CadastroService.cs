using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}
