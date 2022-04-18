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
        public Command SortByTitleCommand { get; }
        public Command SortByLastReadCommand { get; }
        public Command SortByAddedTimeCommand { get; }



        public LibraryViewModel(ILibraryService libraryService)
        {
            Title = "Library";

            _libraryService = libraryService;

            Library = new ObservableCollection<Library>();

            TappedCommand = new Command(onTapped);
            SortByTitleCommand = new Command(onSortByTitle);
            SortByLastReadCommand = new Command(onSortByLastRead);
            SortByAddedTimeCommand = new Command(SortByAddedTime);

        }

        private async void SortByAddedTime(object obj)
        {
            IsBusy = true;
            try
            {
                Library.Clear();

                var books = await _libraryService.SortByAddedTimeToLibrary(Convert.ToInt32(CurrentUser.Id));
                foreach (var book in books)
                {
                    Library temp = new Library
                    {
                        libraryItem = book,
                        progressBar = Convert.ToInt32(((double)book.At_page / book.Page) * 130)
                    };

                    Debug.WriteLine(Convert.ToInt32(((double)book.At_page / book.Page) * 130));
                    Library.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot fetch books");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void onSortByLastRead(object obj)
        {
            IsBusy = true;
            try
            {
                Library.Clear();

                var books = await _libraryService.SortByLastRead(Convert.ToInt32(CurrentUser.Id));
                foreach (var book in books)
                {
                    Library temp = new Library
                    {
                        libraryItem = book,
                        progressBar = Convert.ToInt32(((double)book.At_page / book.Page) * 130)
                    };

                    Debug.WriteLine(Convert.ToInt32(((double)book.At_page / book.Page) * 130));
                    Library.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot fetch books");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void onSortByTitle(object obj)
        {
            IsBusy = true;
            try
            {
                Library.Clear();

                var books = await _libraryService.SortByTitle(Convert.ToInt32(CurrentUser.Id));
                foreach (var book in books)
                {
                    Library temp = new Library
                    {
                        libraryItem = book,
                        progressBar = Convert.ToInt32(((double)book.At_page / book.Page) * 130)
                    };

                    Debug.WriteLine(Convert.ToInt32(((double)book.At_page / book.Page) * 130));
                    Library.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot fetch books");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void PopulateBooks()
        {
            IsBusy = true;
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

                    Debug.WriteLine(Convert.ToInt32(((double)book.At_page / book.Page) * 130));
                    Library.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot fetch books");
                Debug.WriteLine(ex.Message);
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