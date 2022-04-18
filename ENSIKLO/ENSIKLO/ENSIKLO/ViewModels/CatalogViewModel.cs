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
    public class CatalogViewModel : BaseViewModel
    {
        private Book _selectedBook;

        private string topTitleBook;
        private string category;
        private ObservableCollection<Book> booksTop;
        private ObservableCollection<Book> booksBottom;

        public string search_input;

        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }

        public Command RefreshCommand { get; }
        public Command SearchCommand { get; }

        //public Command<Book> BookTapped { get; }

        public CatalogViewModel(IBookService bookService, IUserService userService)
        {
            Title = "Catalog";

            _bookService = bookService;
            _userService = userService;
            topTitleBook = String.Empty;

            BooksTop = new ObservableCollection<Book>();
            BooksBottom = new ObservableCollection<Book>();

            RefreshCommand = new Command(onTappedRefresh);
            SearchCommand = new Command(OnSearchClicked);
        }

        public async Task PopulateBooks()
        {
            IsBusy = true;

            try
            {
                BooksTop.Clear();
                BooksBottom.Clear();

                User curr_user = await _userService.GetCurrentUser();

                var id = curr_user.Id;
     
                var booksTopTemp = await _bookService.GetUserTopGenreBook(id,12);

                foreach (var book in booksTopTemp)
                {
                    BooksTop.Add(book);
                    
                }
                var dataBook = booksTopTemp.AsEnumerable().Select(book => book).ToArray();

                category = dataBook[0].Category;
                category = char.ToUpper(category[0]) + category.Substring(1);

 
                var booksBottomTemp = await _bookService.GetMostPopularBook(12);
                Debug.WriteLine(booksBottomTemp);

                foreach (var book in booksBottomTemp)
                {
                    BooksBottom.Add(book);
                }

                topTitleBook = "Your Top Genre : " + category;
                TopTitleBook = topTitleBook;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                var booksTopTemp = await _bookService.GetSomeRandomBooks(12);

                Debug.WriteLine(booksTopTemp);
                foreach (var book in booksTopTemp)
                {
                    BooksTop.Add(book);

                }
                var dataBook = booksTopTemp.AsEnumerable().Select(book => book).ToArray();

                var booksBottomTemp = await _bookService.GetMostPopularBook(12);
                Debug.WriteLine(booksBottomTemp);

                foreach (var book in booksBottomTemp)
                {
                    BooksBottom.Add(book);
                }

                topTitleBook = "You might like these";
                TopTitleBook = topTitleBook;

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

        public string TopTitleBook
        {
            get => topTitleBook;
            set
            {
                topTitleBook = value;
                OnPropertyChanged(nameof(TopTitleBook));
            }
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

        public string SearchInput
        {
            get => search_input;
            set => SetProperty(ref search_input, value);
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

        private async void onTappedRefresh(object obj)
        {
            OnAppearing();
            await PopulateBooks();
        }

        private async void OnSearchClicked()
        {
            await Shell.Current.GoToAsync($"{nameof(SearchResultPage)}?{nameof(SearchResultViewModel.SearchQuery)}={search_input}");
        }
    }
}
