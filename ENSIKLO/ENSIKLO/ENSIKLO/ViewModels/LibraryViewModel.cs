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
        private Library _selectedBook;

        private ObservableCollection<Library> library;

        private readonly ILibraryService _libraryService;
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }

        public Command TappedCommand { get; }

        public LibraryViewModel(ILibraryService libraryService)
        {
            Title = "Library";

            _libraryService = libraryService;

            Library = new ObservableCollection<Library>();

            TappedCommand = new Command(onTapped);
        }
        public async void PopulateBooks()
        {
            try
            {
                Library.Clear();

                var books = await _libraryService.GetLibraryItemsAsync(Convert.ToInt32(CurrentUser.Id));
                foreach (var book in books)
                {
                    Library temp = new Library
                    {
                        libraryItem = book,
                        progressBar = Convert.ToInt32(((double)book.At_page / book.Page) * 130)
                    };
                    Library.Add(temp);
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

        public ObservableCollection<Library> Library
        {
            get => library;
            set
            {
                library = value;
                OnPropertyChanged(nameof(Library));
            }
        }

        public Library SelectedBook
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


        async void OnBookSelected(Library book)
        {
            if (book == null)
                return;

            if(book.libraryItem.At_page == 0)
            {
                await Shell.Current.GoToAsync($"{nameof(LibraryDetailPage)}?{nameof(LibraryDetailViewModel.BookId)}={book.libraryItem.Id_book}");
            } else
            {
                await Shell.Current.GoToAsync($"{nameof(LibraryReadDetailPage)}?{nameof(LibraryReadDetailViewModel.BookId)}={book.libraryItem.Id_book}");
            }
        
        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//catalog");
        }
    }
}