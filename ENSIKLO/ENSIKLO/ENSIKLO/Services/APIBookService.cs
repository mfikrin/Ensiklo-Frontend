using ENSIKLO.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ENSIKLO.Services
{
    public class APIBookService : IBookService
    {

        private readonly HttpClient _httpClient;

        public APIBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddItemAsync(Book item)
        {
            var response = await _httpClient.PostAsync("Book",
                new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Book/{id}");

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<Book> GetItemAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Book/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Book>(responseAsString);
        }

        public async Task<IEnumerable<Book>> GetItemsAsync(bool forceRefresh = false)
        {
            var response = await _httpClient.GetAsync("Book");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }

        public async Task<bool> UpdateItemAsync(Book item)
        {
            var response = await _httpClient.PutAsync($"Book?id={item.id_book}",
                new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }
    }
}
