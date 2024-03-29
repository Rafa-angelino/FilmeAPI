﻿using AutoMapper;
using FilmeAPI.Data.DTO_S;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
