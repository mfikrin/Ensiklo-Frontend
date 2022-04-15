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
        private LibraryUser _selectedBook;

        private ObservableCollection<LibraryUser> library;

        private readonly ILibraryService _libraryService;
        public Command LoadBooksCommand { get; }

        public Command TappedCommand { get; }

        public LibraryViewModel(ILibraryService libraryService)
        {
            Title = "Library";

            _libraryService = libraryService;

            Library = new ObservableCollection<LibraryUser>();

            TappedCommand = new Command(onTapped);
        }


        public async void PopulateBooks()
        {
            try
            {
                Library.Clear();

                var books = await _libraryService.GetLibraryItemsAsync(1);
                foreach (var book in books)
                {
                    Library.Add(book);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBook = null;
        }

        public ObservableCollection<LibraryUser> Library
        {
            get => library;
            set
            {
                library = value;
                OnPropertyChanged(nameof(Library));
            }
        }

        public LibraryUser SelectedBook
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


        async void OnBookSelected(LibraryUser book)
        {
            if (book == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            if (book.At_page == 0)
            {
                await Shell.Current.GoToAsync($"{nameof(LibraryDetailPage)}?{nameof(LibraryDetailViewModel.BookId)}={book.Id_book}");
            } else
            {
                await Shell.Current.GoToAsync($"{nameof(LibraryReadDetailPage)}?{nameof(LibraryReadDetailViewModel.BookId)}={book.Id_book}");
            }
        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//catalog");
        }
    }
}
