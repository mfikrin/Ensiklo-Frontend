using ENSIKLO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO.Services
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User item);
        Task<string> LoginAsync(LoginRequest loginRequest);
        Task<bool> UpdateUserAsync(User item);
        Task<bool> DeleteUserAsync(Int64 id);
        Task<User> GetUserAsync(Int64 id);
        Task<User> GetCurrentUser();
        Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false);
        //Task<int> GetUserID(string email);
    }
}
