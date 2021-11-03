using Gestevent.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.gestevent
{
    public class GesteventDbContext : DbContext
    {
        public GesteventDbContext(DbContextOptions<GesteventDbContext> options) : base(options)
        {

        }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}