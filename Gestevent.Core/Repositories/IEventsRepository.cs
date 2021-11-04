using Gestevent.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestevent.Core.Repositories
{
    public interface IEventsRepository
    {
        public Task<IEnumerable<EventModel>> GetAll();
        public Task<EventModel> Get(Guid id);
        public Task<EventModel> Add(EventModel evento);
        public Task<bool> Delete(Guid id);
    }
}
