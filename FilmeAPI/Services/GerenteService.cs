using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos.Gerente;
using FilmeAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmeAPI.Services
{
    public class GerenteService
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public GerenteService(IMapper mapper, FilmeContext context)
        {
            _mapper = mapper;
            _context = context; 
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto dto)
        {
            var gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> RecuperaGerente()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();
            if (gerentes == null) return null;
            return _mapper.Map<List<ReadGerenteDto>>(gerentes);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }
            return null;    
        }

        public Result DeletaGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null) return Result.Fail("Gerente não encontrado");

            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
