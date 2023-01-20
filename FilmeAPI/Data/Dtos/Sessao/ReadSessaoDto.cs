using FilmeAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public Cinema Cinema { get; set; }

        public Filme Filme { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }

        public DateTime HorarioDeInicio { get; set; }   
    }
}
