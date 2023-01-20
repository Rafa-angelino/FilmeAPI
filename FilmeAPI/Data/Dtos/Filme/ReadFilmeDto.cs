using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Data.DTO_S
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres")]
        public string Genero { get; set; }
        [Range(1, 400, ErrorMessage = "A duração deve ter entre 1 a 400 minutos")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
