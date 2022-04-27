using ENSIKLO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO.Services
{
    public class DummyUser : IUserService
    {
        readonly List<User> users;

        public DummyUser()
        {
            users = new List<User>()
            {
                new User {Id = 1,Email="fikri@gmail.com",Username="Fikri",Password="Rahasia"},
                new User {Id = 2,Email="fikriClone1@gmail.com",Username="Fikri1",Password="Rahasia1"},
                new User {Id = 3,Email="fikriClone2@gmail.com",Username="Fikri2",Password="Rahasia2"},
            };
        }
        public async Task<bool> AddUserAsync(User item)
        {
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var oldItem = users.Where((User arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public Task<bool> DeleteUserAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public Task<User> GetUserAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }

        public Task<string> LoginAsync(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(User item)
        {
            var oldItem = users.Where((User arg) => arg.Id == item.Id).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(item);

            return await Task.FromResult(true);
        }
    }
}
