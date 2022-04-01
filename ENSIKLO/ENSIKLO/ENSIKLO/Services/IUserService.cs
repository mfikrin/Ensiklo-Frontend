using ENSIKLO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO.Services
{
    internal interface IUserService
    {
        Task<bool> AddItemAsync(User item);
        Task<bool> UpdateItemAsync(User item);
        Task<bool> DeleteItemAsync(int id);
        Task<Book> GetItemAsync(int id);
        Task<IEnumerable<Book>> GetItemsAsync(bool forceRefresh = false);
    }
}
