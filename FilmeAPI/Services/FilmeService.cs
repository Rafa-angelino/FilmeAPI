using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.DTO_S;
using FilmeAPI.Models;
using FluentResults;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Result = FluentResults.Result;

namespace FilmeAPI.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }
            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return filmeDto;
            }
            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return Result.Fail("Nenhum filme encontrada");

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilmes(int id)
        {
            var filme = _context.Cinemas.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return Result.Fail("Nenhum filme encontrada"); 

            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

