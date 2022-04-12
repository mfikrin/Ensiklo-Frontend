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
    public class LibraryViewModel : BaseViewModel
    {
        private Book _selectedBook;

        private ObservableCollection<Book> books;

        private readonly ILibraryService _libraryService;
        public Command LoadBooksCommand { get; }

        public Command TappedCommand { get; }

        //public Command<Book> BookTapped { get; }

        public LibraryViewModel(ILibraryService libraryService)
        {
            Title = "Library";

            _libraryService = libraryService;

            Books = new ObservableCollection<Book>();

            TappedCommand = new Command(onTapped);
        }


        public async void PopulateBooks()
        {
            try
            {
                Books.Clear();

                var books = await _libraryService.GetLibraryItemsAsync(1);
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
