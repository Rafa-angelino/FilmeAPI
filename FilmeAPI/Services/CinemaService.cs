using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.DTO_S;
using FilmeAPI.Data.DTO_S.Cinema;
using FilmeAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmeAPI.Services
{
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeDofilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null) return null;
            if (!string.IsNullOrEmpty(nomeDofilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDofilme)
                                            select cinema;
                cinemas = query.ToList();
            }
           return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemaPorId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }
            return null;
        }

        public Result AtualizaCinemas(int id, UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return Result.Fail("Não foi encontrado cinemas");

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return Result.Fail("Não foi encontrado cinemas");

            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
