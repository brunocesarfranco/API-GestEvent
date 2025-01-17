﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Gestevent.Core.Models
{
    public class TicketModel : Entity
    {

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O preço deve ser Maior q zero")]
        public decimal Price { get; set; }

        public UserModel User { get; set; }
        public Guid ? UserId { get; set; }

        [Required]
        public Guid EventId { get; set; }
        public bool WasSold { get; set; } = true;
    }
}
