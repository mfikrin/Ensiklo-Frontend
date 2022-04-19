using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    [QueryProperty(nameof(SearchQuery), nameof(SearchQuery))]
    public class SearchLibraryViewModel : BaseViewModel
    {
        private Library _selectedBook;

        private ObservableCollection<Library> librarySearch;

        public string search_input;
        public string search_query;

        private readonly ILibraryService _libraryService;
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }

        public Command RefreshCommand { get; }
        public Command SearchCommand { get; }

        //public Command<Book> BookTapped { get; }

        public SearchLibraryViewModel(ILibraryService libraryService)
        {
            Title = "Catalog";

            _libraryService = libraryService;

            LibrarySearch = new ObservableCollection<Library>();

            RefreshCommand = new Command(onTappedRefresh);
            SearchCommand = new Command(OnSearchClicked);
        }

        public async void PopulateBooks()
        {
            IsBusy = true;
            Debug.WriteLine("POPULATING");

            try
            {
                LibrarySearch.Clear();
                Debug.WriteLine("ID USER IN SEARCH LIBRARY VIEW MODEL");
                Debug.WriteLine(Convert.ToInt32(CurrentUser.Id));

                var booksBottomTemp = await _libraryService.SearchBooks(SearchQuery, Convert.ToInt32(CurrentUser.Id));


                Debug.WriteLine(SearchQuery);
                Debug.WriteLine("BANYAK HASIL SEARCH");
                Debug.WriteLine(booksBottomTemp.Count());

                foreach (var book in booksBottomTemp)
                {
                    Library temp = new Library
                    {
                        libraryItem = book,
                        progressBar = Convert.ToInt32(((double)book.At_page / book.Page) * 130)
                    };

                    Debug.WriteLine(Convert.ToInt32(((double)book.At_page / book.Page) * 130));
                    LibrarySearch.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("POPULATING: ERROR");
                Debug.WriteLine(ex);
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

        public ObservableCollection<Library> LibrarySearch
        {
            get => librarySearch;
            set
            {
                librarySearch = value;
                OnPropertyChanged(nameof(LibrarySearch));
            }
        }

        public string SearchInput
        {
            get => search_input;
            set => SetProperty(ref search_input, value);
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

        public string SearchQuery
        {
            get => search_query;
            set
            {
                search_query = value;
                SearchInput = value;
                PopulateBooks();
            }
        }


        async void OnBookSelected(Library book)
        {
            if (book == null)
                return;

            if (book.libraryItem.At_page == 0)
            {
                await Shell.Current.GoToAsync($"{nameof(LibraryDetailPage)}?{nameof(LibraryDetailViewModel.BookId)}={book.libraryItem.Id_book}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(LibraryReadDetailPage)}?{nameof(LibraryReadDetailViewModel.BookId)}={book.libraryItem.Id_book}");
            }

        }

        private async void onTappedRefresh(object obj)
        {
            OnAppearing();
            PopulateBooks();
        }

        private async void OnSearchClicked()
        {
            //await Shell.Current.Navigation.PopAllPopupAsync();
            await Shell.Current.Navigation.PopAsync();
            await Shell.Current.GoToAsync($"{nameof(SearchLibraryPage)}?{nameof(SearchLibraryViewModel.SearchQuery)}={search_input}");
        }
    }
}
