using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ENSIKLO.Models;

namespace ENSIKLO.Services
{
    public interface ILibraryUserService
    {
        Task<List<int>> GetFinishedBooks(Int64 id_user);
    }
}
