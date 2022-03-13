﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSIKLO.Models;

namespace ENSIKLO.Services
{
    public class DummyBookStore : IBookService
    {
        readonly List<Book> books;
        public DummyBookStore()
        {
            books = new List<Book>()
            {
                new Book {
                   Id_book = 1,Title="judul1",Description_book="deskripsi1",Publisher="PT.GRAME",
                    Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"},
                new Book {
                   Id_book = 2,Title="judul2",Description_book="deskripsi2",Publisher="PT.GRAME",
                    Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"},
                new Book {
                   Id_book = 3,Title="judul3",Description_book="deskripsi3",Publisher="PT.GRAME",
                    Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"},
                new Book {
                   Id_book = 4,Title="judul4",Description_book="deskripsi4",Publisher="PT.GRAME",
                    Url_cover="https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"},

            };
        }
        public async Task<bool> AddItemAsync(Book item)
        {
            books.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = books.Where((Book arg) => arg.Id_book == id).FirstOrDefault();
            books.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Book> GetItemAsync(int id)
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
