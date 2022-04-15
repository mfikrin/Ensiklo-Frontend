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
    public class NewArrivalViewModel : BaseViewModel
    {
        private Book _selectedBook;

        private ObservableCollection<Book> booksNewArrival;

        private readonly IBookService _bookService;
        public Command LoadBooksCommand { get; }
        //public Command<object> ThreeDotCommand { get; }

 

        public NewArrivalViewModel(IBookService bookService)
        {
            Title = "New Arrival Books";

            _bookService = bookService;

            booksNewArrival = new ObservableCollection<Book>();
     
        }

        public async Task PopulateBooks()
        {
            IsBusy = true;

            try
            {
                BooksNewArrival.Clear();
              
                var booksNewArrivalTemp = await _bookService.GetAllNewArrivalBooks();

                Debug.WriteLine(booksNewArrivalTemp);
                foreach (var book in booksNewArrivalTemp)
                {
                    BooksNewArrival.Add(book);

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

        public ObservableCollection<Book> BooksNewArrival
        {
            get => booksNewArrival;
            set
            {
                booksNewArrival = value;
                OnPropertyChanged(nameof(BooksNewArrival));
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
    }
}
