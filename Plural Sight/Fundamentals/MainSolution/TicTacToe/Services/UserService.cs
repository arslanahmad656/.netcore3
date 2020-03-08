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
        private readonly ConcurrentDictionary<string, UserModel> _usersIndexedByEmail;
        private readonly ConcurrentDictionary<Guid, UserModel> _usersIndexedById;

        private bool AddUser(UserModel user)
        {
            if (!_usersIndexedById.ContainsKey(user.Id))
            {
                _usersIndexedById.TryAdd(user.Id, user);
                _usersIndexedByEmail.TryAdd(user.Email, user);
                return true;
            }

            return false;
        }

        private async Task RemoveByEmail(string email)
        {
            var userToRemove = await GetUserByEmail(email);
            if (userToRemove != null)
            {
                RemoveIndex(userToRemove.Email, userToRemove.Id);
            }
        }

        private async Task RemoveById(Guid id)
        {
            var userToRemove = await GetUserById(id);
            if (userToRemove != null)
            {
                RemoveIndex(userToRemove.Email, userToRemove.Id);
            }
        }

        private void RemoveIndex(string email, Guid id)
        {
            _usersIndexedByEmail.Remove(email, out _);
            _usersIndexedById.Remove(id, out _);
        }

        public async Task<UserModel> GetUserByEmail(string email)
            => await Task.FromResult(_usersIndexedByEmail.GetValueOrDefault(email));

        public async Task<UserModel> GetUserById(Guid id)
            => await Task.FromResult(_usersIndexedById.GetValueOrDefault(id));

        public UserService()
        {
            _usersIndexedByEmail = new ConcurrentDictionary<string, UserModel>();
            _usersIndexedById = new ConcurrentDictionary<Guid, UserModel>();
        }

        public async Task<bool> CreateUser(UserModel userModel)
        {
            return await Task.FromResult(AddUser(userModel));
        }

        public async Task<bool> IsOnline(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(UserModel user)
        {
            var userToUpdate = await GetUserById(user.Id);
            if (userToUpdate != null)
            {
                await RemoveById(userToUpdate.Id);
                AddUser(user);
            }
        }

        public async Task<bool> ConfirmEmail(string email)
        {
            var userToConfirm = await GetUserByEmail(email);
            if (userToConfirm == null)
            {
                return false;
            }

            if (userToConfirm.IsEmailConfirmed)
            {
                return true;
            }

            userToConfirm.IsEmailConfirmed = true;
            userToConfirm.EmailConfirmationDate = DateTime.Now;
            await UpdateUser(userToConfirm);
            return true;
        }
    }
}
