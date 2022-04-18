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


        public async Task<bool> AddToLibraryAsync(LibraryUser libraryUser)
        {

            // TODO: add Id
            var response = await _httpClient.PostAsync("LibraryUser",new StringContent(JsonSerializer.Serialize(libraryUser), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteFromLibraryAsync(int userId, int bookId)
        {
            var response = await _httpClient.DeleteAsync($"LibraryUser/{userId}/{bookId}");

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<LibraryUser>> GetLibraryItemsAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/{userId}");

            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync(); 
            return JsonSerializer.Deserialize<IEnumerable<LibraryUser>>(responseAsString);
        }

        public async Task<LibraryUser> GetLibraryItemAsync(int userId, int bookId)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/get/{userId}/{bookId}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);
            return JsonSerializer.Deserialize<LibraryUser>(removeSqrBracket);
        }

        public async Task<IEnumerable<LibraryUser>> SortByTitle(int userId)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/sort/title/{userId}");

            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<LibraryUser>>(responseAsString);
        }

        public async Task<IEnumerable<LibraryUser>> SortByAddedTimeToLibrary(int userId)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/sort/AddedTime/{userId}");

            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<LibraryUser>>(responseAsString);
        }

        public async Task<IEnumerable<LibraryUser>> SortByLastRead(int userId)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/sort/LastRead/{userId}");

            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<LibraryUser>>(responseAsString);
        }

        public async Task<List<int>> GetFinishedBooks(Int64 id_user)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/FinishedBooks/{id_user}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(responseAsString);
            var tesjson = JsonSerializer.Deserialize<IEnumerable<LibraryUser>>(responseAsString);
            //Debug.WriteLine(tesjson);

            List<int> finishedbooks = new List<int>();
            foreach (var item in tesjson)
            {
                Debug.WriteLine(item.Id_book);
                finishedbooks.Add(item.Id_book);
            }

            return finishedbooks;
        }
    }
}
