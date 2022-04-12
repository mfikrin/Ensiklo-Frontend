using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ENSIKLO.Models;

namespace ENSIKLO.Services
{
    public interface IBookService
    {
        Task<bool> AddItemAsync(Book item);
        Task<bool> UpdateItemAsync(Book item);
        Task<bool> DeleteItemAsync(int id);
        Task<Book> GetItemAsync(int id);
        Task<IEnumerable<Book>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<Book>> GetUserTopGenreBook(int id_user, int limit, bool forceRefresh = false);
        Task<IEnumerable<Book>> GetMostPopularBook(int limit, bool forceRefresh = false);

    }
}
