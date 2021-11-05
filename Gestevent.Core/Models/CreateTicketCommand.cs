using System;
using System.ComponentModel.DataAnnotations;

namespace Gestevent.Core.Models
{
    public class CreateTicketCommand
    {
        [Required]
        public Guid EventId { get; set; }
        
        [Range(0.01, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
