﻿using FilmeAPI.Models;
using System.Collections.Generic;

namespace FilmeAPI.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public object Cinemas { get; set; }   
    }
}
