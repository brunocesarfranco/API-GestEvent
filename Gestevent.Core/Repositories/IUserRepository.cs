using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestevent.Core.Models;

namespace Gestevent.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> Get(Guid guid);
        public Task<User> Add(User user);
        public Task<bool> Delete(Guid id);
        public Task<dynamic> Authenticate(User user);
    }
}
