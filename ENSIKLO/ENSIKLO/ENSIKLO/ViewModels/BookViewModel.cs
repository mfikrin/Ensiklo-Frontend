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
    public class BookViewModel : BaseViewModel
    {
        private Book _selectedBook;

        private ObservableCollection<Book> books;

        private readonly IBookService _bookService;
        public Command LoadBooksCommand { get; }
        //public Command<object> ThreeDotCommand { get; }

        public Command TappedCommand { get; }

        //public Command<Book> BookTapped { get; }

        public BookViewModel(IBookService bookService)
        {
            Title = "Browse";

            _bookService = bookService;

            Books = new ObservableCollection<Book>();

            //LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());

            //BookTapped = new Command<Book>(OnBookSelected);


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
                Books.Clear();

                var books = await _bookService.GetItemsAsync();
                foreach (var book in books)
                {
                    Books.Add(book);
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

        public ObservableCollection<Book> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
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

        private async void OnAddBook(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewBookPage));
        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//catalog");
        }
    }
}