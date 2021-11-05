using Gestevent.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestevent.Core.Repositories
{
    public interface ITicketsRepository
    {
        public Task<IEnumerable<TicketModel>> GetAll();
        public Task<TicketModel> Get(Guid guid);
        public Task<TicketModel> Add(TicketModel ticket);
        public Task<bool> Delete(Guid id);
    }
}
