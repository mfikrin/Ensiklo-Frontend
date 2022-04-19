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
        Task<IEnumerable<LibraryUser>> SortByTitle(int userId);
        Task<IEnumerable<LibraryUser>> SortByAddedTimeToLibrary(int userId);
        Task<IEnumerable<LibraryUser>> SortByLastRead(int userId);
        Task<LibraryUser> GetLibraryItemAsync(int userId, int bookId);
        Task<List<int>> GetFinishedBooks(Int64 id_user);
        Task<IEnumerable<LibraryUser>> SearchBooks(string query, int userId);

    }
}
