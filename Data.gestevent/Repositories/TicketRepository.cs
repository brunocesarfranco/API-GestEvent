using Gestevent.Core.Models;
using Gestevent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.gestevent.Repositories
{
    public class TicketRepository : ITicketsRepository
    {
        private readonly GesteventDbContext _gesteventDbContext;

        public TicketRepository(GesteventDbContext gesteventDbContext)
        {
            _gesteventDbContext = gesteventDbContext;
        }

        public async Task<TicketModel> Add(TicketModel ticket)
        {

            _gesteventDbContext.Add(ticket);
            await _gesteventDbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> Delete(Guid id)
        {
            var aTicket = await _gesteventDbContext.Tickets
                .FirstOrDefaultAsync(e => e.Id == id);

            if (aTicket is null)
            {
                return false;
            }

            _gesteventDbContext.Tickets.Remove(aTicket);

            await _gesteventDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TicketModel> Get(Guid id)
        {
            var aTicket = await _gesteventDbContext.Tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return aTicket;
        }

        public async Task<IEnumerable<TicketModel>> GetAll()
        {
            var tickets = await _gesteventDbContext.Tickets
                .AsNoTracking()
                .ToListAsync();
            return tickets;
        }
    }
}
