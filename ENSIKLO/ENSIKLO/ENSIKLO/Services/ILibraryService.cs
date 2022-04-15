using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ENSIKLO.Models;

namespace ENSIKLO.Services
{
    public interface ILibraryService
    {
        Task<bool> AddToLibraryAsync(LibraryUser libraryUser);
        Task<bool> DeleteFromLibraryAsync(int userId, int bookId);
        Task<IEnumerable<LibraryUser>> GetLibraryItemsAsync(int userId);
        Task<LibraryUser> GetLibraryItemAsync(int userId, int bookId);
    }
}
