﻿using ENSIKLO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO.Services
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User item);
        Task<bool> UpdateUserAsync(User item);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false);
        Task<int> GetUserID(string email);
    }
}