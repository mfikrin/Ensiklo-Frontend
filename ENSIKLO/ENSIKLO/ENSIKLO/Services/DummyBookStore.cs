using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSIKLO.Models;

namespace ENSIKLO.Services
{
    public class DummyBookStore : IDataStore<Book>
    {
        readonly List<Book> books;
        public DummyBookStore()
        {
            books = new List<Book>()
            {
                new Book {Id_book = "1", Title="judul1",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "2", Title="judul2",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "3", Title="judul3",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "4", Title="judul4",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "5", Title="judul5",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "6", Title="judul6",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "7", Title="judul7",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "8", Title="judul8",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "9", Title="judul9",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "10", Title="judul10",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "11", Title="judul11",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
                new Book {Id_book = "12", Title="judul12",Rating=5,Description_book="deskripsi1",Pages=123,Publisher="PT.GRAME",Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg", Author_names="author"},
            
            };
        }
        public async Task<bool> AddItemAsync(Book item)
        {
            books.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = books.Where((Book arg) => arg.Id_book == id).FirstOrDefault();
            books.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Book> GetItemAsync(string id)
        {
            return await Task.FromResult(books.FirstOrDefault(s => s.Id_book == id));
        }

        public async Task<IEnumerable<Book>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(books);
        }

        public async Task<bool> UpdateItemAsync(Book item)
        {
            var oldItem = books.Where((Book arg) => arg.Id_book == item.Id_book).FirstOrDefault();
            books.Remove(oldItem);
            books.Add(item);

            return await Task.FromResult(true);
        }
    }
}
