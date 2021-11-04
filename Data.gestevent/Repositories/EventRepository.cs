using Gestevent.Core.Models;
using Gestevent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.gestevent.Repositories
{
    public class EventRepository : IEventsRepository
    {
        private readonly GesteventDbContext _gesteventDbContext;

        public EventRepository(GesteventDbContext gesteventDbContext)
        {
            _gesteventDbContext = gesteventDbContext;
        }
        public async Task<EventModel> Add(EventModel evento)
        {

            _gesteventDbContext.Add(evento);
            await _gesteventDbContext.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> Delete(Guid id)
        {
            var aEvent = await _gesteventDbContext.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (aEvent is null) 
            {
                return false;
            }

            _gesteventDbContext.Events.Remove(aEvent);

            await _gesteventDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<EventModel> Get(Guid id)
        {
            var aEvent = await _gesteventDbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return aEvent;
        }

        public async Task<IEnumerable<EventModel>> GetAll()
        {
            var events = await _gesteventDbContext.Events
                .AsNoTracking()
                .ToListAsync();
            return events;
        }
    }
}
