using System;
using System.ComponentModel.DataAnnotations;

namespace Gestevent.Core.Models
{
    public class TicketModel : Entity
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O preço deve ser Maior q zero")]
        public decimal Price { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

        public EventModel Event { get; set; }

    }
}
