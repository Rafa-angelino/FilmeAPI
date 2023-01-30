using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos.Sessao;
using FilmeAPI.Models;
using System;
using System.Linq;

namespace FilmeAPI.Services
{
    public class SessaoService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            var sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);  
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return sessaoDto;
            }
            return null;
        }
    }
}
