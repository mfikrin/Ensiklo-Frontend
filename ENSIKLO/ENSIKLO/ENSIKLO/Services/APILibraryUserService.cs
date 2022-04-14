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
    public class APILibraryUserService : ILibraryUserService
    {

        private readonly HttpClient _httpClient;

        public APILibraryUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<int>> GetFinishedBooks(Int64 id_user)
        {
            var response = await _httpClient.GetAsync($"LibraryUser/FinishedBooks/{id_user}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(responseAsString);
            var tesjson = JsonSerializer.Deserialize<IEnumerable<LibraryUser>>(responseAsString);
            //Debug.WriteLine(tesjson);

            List <int> finishedbooks = new List<int>();
            foreach (var item in tesjson)
            {
                Debug.WriteLine(item.Id_book);
                finishedbooks.Add(item.Id_book);
            }

            return finishedbooks;
        }
    }
}
