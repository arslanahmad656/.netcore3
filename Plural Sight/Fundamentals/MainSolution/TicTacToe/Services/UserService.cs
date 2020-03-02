using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public class UserService : IUserService
    {
        public async Task<bool> CreateUser(UserModel userModel)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> IsOnline(Guid userId)
        {
            return await Task.FromResult(false);
        }
    }
}
