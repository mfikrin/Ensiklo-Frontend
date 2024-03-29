﻿using ENSIKLO.Models;
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
            var response = await _httpClient.PostAsync("User/register",
            new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<string> LoginAsync(LoginRequest item)
        {
            var response = await _httpClient.PostAsync("User/login",
            new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public Task<bool> DeleteUserAsync(Int64 id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(Int64 id)
        {
            var response = await _httpClient.GetAsync($"User/getUser/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            return JsonSerializer.Deserialize<User>(removeSqrBracket);
        }

        public async Task<User> GetCurrentUser()
        {
            var response = await _httpClient.GetAsync($"User/currentUser");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            return JsonSerializer.Deserialize<User>(removeSqrBracket);
        }

        public async Task<bool> LogoutUserAsync()
        {
            var response = await _httpClient.PostAsync($"User/Logout?token={CurrentUser.Token}",
            new StringContent(JsonSerializer.Serialize(""), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            return await Task.FromResult(true);
        }

        public Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(User item)
        {
            var response = await _httpClient.PutAsync($"User/updateUser/{CurrentUser.Id}",
            new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));
            Debug.WriteLine(response);
            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        //public async Task<int> GetUserID(string email)
        //{
        //    var response = await _httpClient.GetAsync($"User/id/{email}");

        //    response.EnsureSuccessStatusCode();

        //    var responseAsString = await response.Content.ReadAsStringAsync();
        //    //Debug.WriteLine(responseAsString);

        //    var removeSqrBracket = responseAsString.Substring(12);
        //    var remove2char = removeSqrBracket.Substring(0, removeSqrBracket.Length - 2);

        //    //Debug.WriteLine(remove2char);

        //    //removesqrbracket {"id_user":3}
        //    return int.Parse(remove2char);
        //}
    }
}
