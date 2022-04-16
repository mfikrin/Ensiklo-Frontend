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
            //Debug.WriteLine(responseAsString);

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            //Debug.WriteLine(removeSqrBracket);

            //responseAsString = @"{""id_book"":1,""title"":""test judul"",""author"":""siapa"",""publisher"":""Gra"",""year_published"":""2001"",""description_book"":""bagus bgt lho"",""book_content"":""https://www.google.com"",""url_cover"":""https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"",""category"":""science"",""keywords"":""science, nature""}";
            return JsonSerializer.Deserialize<User>(removeSqrBracket);
        }

        public async Task<User> GetCurrentUser()
        {
            var response = await _httpClient.GetAsync($"User/currentUser");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(responseAsString);

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            //Debug.WriteLine(removeSqrBracket);

            //responseAsString = @"{""id_book"":1,""title"":""test judul"",""author"":""siapa"",""publisher"":""Gra"",""year_published"":""2001"",""description_book"":""bagus bgt lho"",""book_content"":""https://www.google.com"",""url_cover"":""https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"",""category"":""science"",""keywords"":""science, nature""}";
            return JsonSerializer.Deserialize<User>(removeSqrBracket);
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
    }
}
