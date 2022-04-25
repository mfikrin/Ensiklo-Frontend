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
        Task<IEnumerable<Book>> GetAllNewArrivalBooks(bool forceRefresh = false);
        Task<IEnumerable<Book>> GetUserTopGenreBook(Int64 id_user, int limit, bool forceRefresh = false);
        Task<IEnumerable<Book>> GetMostPopularBook(int limit, bool forceRefresh = false);
        Task<IEnumerable<Book>> GetNewArrivalBook(int limit, bool forceRefresh = false);
        Task<IEnumerable<Book>> GetSomeRandomBooks(int limit, bool forceRefresh = false);
        Task<IEnumerable<Book>> SearchBooks(string query);
        Task<IEnumerable<Book>> GetByPublisher(string query);
        Task<IEnumerable<Book>> GetByAuthor(string query);

    }
}
