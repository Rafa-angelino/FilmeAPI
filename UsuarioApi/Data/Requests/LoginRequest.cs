﻿using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Usernamme { get; set; }

        [Required]

        public string Password { get; set; }    
    }
}
