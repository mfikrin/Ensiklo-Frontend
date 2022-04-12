﻿using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {
        private Book _selectedBook;

        private ObservableCollection<Book> booksTop;
        private ObservableCollection<Book> booksBottom;


        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }
        //public Command<object> ThreeDotCommand { get; }

        public Command TappedCommand { get; }

        //public Command<Book> BookTapped { get; }

        public CatalogViewModel(IBookService bookService, IUserService userService)
        {
            Title = "Catalog";

            _bookService = bookService;
            _userService = userService;
            BooksTop = new ObservableCollection<Book>();
            BooksBottom = new ObservableCollection<Book>();

            TappedCommand = new Command(onTapped);
        }

        //async Task ExecuteLoadBooksCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Books.Clear();
        //        var books = await _bookService.GetItemsAsync(true);
        //        foreach (var book in books)
        //        {
        //            Books.Add(book);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        public async Task PopulateBooks()
        {
            IsBusy = true;

            try
            {
                BooksTop.Clear();
                BooksBottom.Clear();

                User curr_user = await _userService.GetCurrentUser();

                var id = curr_user.Id;
                Debug.WriteLine("ID USER");
                Debug.WriteLine(id);

                var booksTopTemp = await _bookService.GetUserTopGenreBook(id,5);
                foreach (var book in booksTopTemp)
                {
                    BooksTop.Add(book);
                }

                var booksBottomTemp = await _bookService.GetMostPopularBook(5);
                foreach (var book in booksBottomTemp)
                {
                    BooksBottom.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBook = null;
        }

        public ObservableCollection<Book> BooksTop
        {
            get => booksTop;
            set
            {
                booksTop = value;
                OnPropertyChanged(nameof(BooksTop));
            }
        }

        public ObservableCollection<Book> BooksBottom
        {
            get => booksBottom;
            set
            {
                booksBottom = value;
                OnPropertyChanged(nameof(BooksBottom));
            }
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (_selectedBook != value)
                {
                    SetProperty(ref _selectedBook, value);
                    OnBookSelected(value);
                }

            }
        }


        async void OnBookSelected(Book book)
        {
            if (book == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.Id_book}");
        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//catalog");
        }
    }
}
