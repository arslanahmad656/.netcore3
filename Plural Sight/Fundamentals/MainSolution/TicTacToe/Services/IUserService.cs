using System;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserModel userModel);
        Task<bool> IsOnline(Guid userId);
    }
}