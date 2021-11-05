using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gestevent.Core.Models;

namespace Gestevent.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserModel>> GetAll();
        public Task<UserModel> Get(Guid guid);
        public Task<UserModel> Add(UserModel user);
        public Task<bool> Delete(Guid id);
        public Task<dynamic> Authenticate(LoginFormModel user);
    }
}
