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
    public class APILibraryService : ILibraryService
    {

        private readonly HttpClient _httpClient;

        public APILibraryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<bool> AddToLibraryAsync(int userId int bookId)
        {

            // TODO: add Id
            var response = await _httpClient.PostAsync("LibraryUser",new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteFromLibraryAsync(int userId, int bookId)
        {
            var response = await _httpClient.DeleteAsync($"LibraryUser/{userId}/{bookId}");

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Book>> GetLibraryItemsAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/{userId}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }
    }
}
