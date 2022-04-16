using ENSIKLO.Models;
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

        private ObservableCollection<Book> booksTop;
        private ObservableCollection<Book> booksBottom;

        private readonly IBookService _bookService;
        public Command LoadBooksCommand { get; }
        public Command AllNewArrivalCommand { get; }

        public Command RefreshCommand { get; }

        public BookViewModel(IBookService bookService)
        {
            Title = "Browse";

            _bookService = bookService;

            booksTop = new ObservableCollection<Book>();
            booksBottom = new ObservableCollection<Book>();

            RefreshCommand = new Command(onTappedRefresh);


            AllNewArrivalCommand = new Command(onTappedNewArrival);
        }

        public async Task PopulateBooks()
        {
            IsBusy = true;

            try
            {
                BooksTop.Clear();
                BooksBottom.Clear();

           

                var booksTopTemp = await _bookService.GetNewArrivalBook(12);

                Debug.WriteLine(booksTopTemp);
                foreach (var book in booksTopTemp)
                {
                    BooksTop.Add(book);

                }

                var booksBottomTemp = await _bookService.GetSomeRandomBooks(12);
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
                booksBottom = value;
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

        private async void onTappedNewArrival(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewArrivalBooksPage));
        }

        public async Task PopulateBooksBottom()
        {
            IsBusy = true;

            try
            {
                BooksBottom.Clear();

                var booksBottomTemp = await _bookService.GetSomeRandomBooks(12);
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

      
        private async void onTappedRefresh(object obj)
        {
            OnAppearing();
            await PopulateBooksBottom();
        }
    }
}