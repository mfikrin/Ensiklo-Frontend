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
        private readonly ILibraryService _libraryService;
        public Command LoadBooksCommand { get; }
        //public Command<object> ThreeDotCommand { get; }

        public Command AllNewArrivalCommand { get; }

        public Command RefreshCommand { get; }

        //public Command<Book> BookTapped { get; }

        public BookViewModel(IBookService bookService, ILibraryService libraryService)
        {
            Title = "Browse";

            _bookService = bookService;
            _libraryService = libraryService;

            booksTop = new ObservableCollection<Book>();
            booksBottom = new ObservableCollection<Book>();

            //LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());

            //BookTapped = new Command<Book>(OnBookSelected);
            RefreshCommand = new Command(onTappedRefresh);


            AllNewArrivalCommand = new Command(onTappedNewArrival);
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

        //public async Task PopulateBooks()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Books.Clear();

        //        var books = await _bookService.GetItemsAsync();
        //        foreach (var book in books)
        //        {
        //            Books.Add(book);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
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
            
            try
            {
                var select = await _libraryService.GetLibraryItemAsync(Convert.ToInt32(CurrentUser.Id), book.Id_book);
                // if pass in here, select should not null

                //if (select != null)
                //{

                //}

                if (select.At_page == 0)
                {
                    await Shell.Current.GoToAsync($"{nameof(LibraryDetailPage)}?{nameof(LibraryDetailViewModel.BookId)}={select.Id_book}");
                }
                else
                {
                    await Shell.Current.GoToAsync($"{nameof(LibraryReadDetailPage)}?{nameof(LibraryReadDetailViewModel.BookId)}={select.Id_book}");
                }
                
                //else
                //{
                //    // This will push the ItemDetailPage onto the navigation stack
                //    Debug.WriteLine("DI ELSE");
                //    await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.Id_book}");
                //}

            } catch (Exception ex)
            {
                //Debug.WriteLine("masuk exception book view model");
                Debug.WriteLine(ex.Message);
                await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.Id_book}");
            }
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