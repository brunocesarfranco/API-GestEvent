﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestevent.Core.Models
{
    public class User : Entity
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Role { get; set; }

    }
}