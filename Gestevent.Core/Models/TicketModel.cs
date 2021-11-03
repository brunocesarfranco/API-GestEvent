using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
