using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public class UserService : IUserService
    {
        private readonly ConcurrentBag<UserModel> _users;

        public UserService()
        {
            _users = new ConcurrentBag<UserModel>();
        }

        public async Task<bool> CreateUser(UserModel userModel)
        {
            _users.Add(userModel);
            return await Task.FromResult(true);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)));
        }

        public async Task<bool> IsOnline(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
