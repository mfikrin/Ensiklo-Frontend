using ENSIKLO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ENSIKLO.Services
{
    internal class APIUserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public APIUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddUserAsync(User item)
        {
            var response = await _httpClient.PostAsync("user/register",
            new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
