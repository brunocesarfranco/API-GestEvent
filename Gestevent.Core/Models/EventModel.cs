using System;
using System.ComponentModel.DataAnnotations;

namespace Gestevent.Core.Models
{
    public class EventModel : Entity
    { 
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [MaxLength(1024, ErrorMessage = "Este campo deve conter no maximo 1024 caracteres")]
        public string Description { get; set; }
    }
}
