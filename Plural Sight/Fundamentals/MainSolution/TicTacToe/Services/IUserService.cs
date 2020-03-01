using System;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public interface IUserService
    {
        Task<bool> IsOnline(Guid userId);
        Task<bool> RegisterUser(UserModel userModel);
    }
}