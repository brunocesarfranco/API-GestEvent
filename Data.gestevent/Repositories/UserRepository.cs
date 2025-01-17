﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gestevent.Core.Models;
using Gestevent.Core.Repositories;
using Gestevent.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.gestevent.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly GesteventDbContext _gesteventDbContext;
        public UserRepository(GesteventDbContext gesteventDbContext)
        {
            _gesteventDbContext = gesteventDbContext;
        }

        public async Task<UserModel> Add(UserModel user)
        {
            _gesteventDbContext.Users.Add(user);
            await _gesteventDbContext.SaveChangesAsync();
            user.Password = "**********";
            return user;
           
        }

        public async Task<dynamic> Authenticate(LoginFormModel user)
        {
            
            try
            {
                var login = await _gesteventDbContext.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => 
                        x.Username == user.Username && 
                        x.Password == user.Password);

                if(login is null)
                {
                    return null;
                }

                var token = TokenService.GenerateToken(login);
                user.Password = "**********";

                return new {
                    user = user,
                    token = token
                };

            }
            catch(Exception ex)
            {
                return ex;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var aUser = await _gesteventDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == id);

            if (aUser is null)
            {
                return false;
            }

            _gesteventDbContext.Users.Remove(aUser);

            await _gesteventDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<UserModel> Get(Guid id)
        {
            var aUser = await _gesteventDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id );
            return aUser;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var users = await _gesteventDbContext.Users
                .AsNoTracking()
                .ToListAsync();
            return users;
        }
    }
}
