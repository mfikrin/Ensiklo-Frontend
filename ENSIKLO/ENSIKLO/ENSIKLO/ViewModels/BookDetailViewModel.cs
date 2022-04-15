using Acr.UserDialogs;
using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class BookDetailViewModel : BaseViewModel
    {
    
        private string id_book ;

        private string title ;

        private string author ;

        private string publisher ;

        private DateTime year_published ;

        private string description_book ;

        private string book_content ;

        private string url_cover ;

        private string category ;

        private string keywords ;

        private readonly IBookService _bookService;
        private readonly ILibraryService _libraryService;
        public Command DeleteBookCommand { get; }
        public Command AddToLibraryCommand { get; set; }
        public BookDetailViewModel(IBookService bookService, ILibraryService libraryService)
        {
            _bookService = bookService;
            _libraryService = libraryService;

            DeleteBookCommand = new Command(async bookid => await OnDeleteBook(bookid: BookId));
        
            AddToLibraryCommand = new Command(async userId => await AddToLibrary(userId: "1", bookId: BookId));

            //DeleteBookCommand = new Command(async () => await OnDeleteBook());
        }

        

        public int Id { get; set; }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public string Publisher
        {
            get => publisher;
            set => SetProperty(ref publisher, value);
        }

        public DateTime Year_published
        {
            get => year_published;
            set => SetProperty(ref year_published, value);
        }

        public string Description_book
        {
            get => description_book;
            set => SetProperty(ref description_book, value);
        }

        public string Book_content
        {
            get => book_content;
            set => SetProperty(ref book_content, value);
        }

        public string Url_cover
        {
            get => url_cover;
            set => SetProperty(ref url_cover, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public string Keywords
        {
            get => keywords;
            set => SetProperty(ref keywords, value);
        }


        public string BookId
        {
            get => id_book;
            set
            {
                id_book = value;
                LoadBookId(id_book);
                
            }
        }

        public async void LoadBookId(string bookId)
        {
            try
            {
                var book = await _bookService.GetItemAsync(int.Parse(bookId));
                Debug.WriteLine("Pass in here");
                if (bookId != null)
                {
                    Id = book.Id_book;
                    Title = book.Title;
                    Author = book.Author;
                    Publisher = book.Publisher;
                    Year_published = book.Year_published;
                    Description_book = book.Description_book;
                    Book_content = book.Book_content;
                    Url_cover = book.Url_cover;
                    Category = book.Category;
                    Keywords = book.Keywords;
                }
                  
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item");
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task OnDeleteBook(string bookid)
        {
            Debug.WriteLine("On delete Book");
            Debug.WriteLine(bookid);

            await _bookService.DeleteItemAsync(int.Parse(bookid));
            await Shell.Current.GoToAsync(nameof(BooksPage));

            



        }

        private async Task AddToLibrary(string userId, string bookId)
        {
            Debug.WriteLine(bookId);

            try
            {
                var book = await _bookService.GetItemAsync(int.Parse(bookId));
                if (bookId != null)
                {
                    LibraryUser libraryUser = new LibraryUser
                    {
                        Id_user = int.Parse(userId),
                        Id_book = int.Parse(bookId),
                        Title = book.Title,
                        Author = book.Author,
                        Publisher = book.Publisher,
                        Year_published = book.Year_published,
                        Description_book = book.Description_book,
                        Book_content = book.Book_content,
                        Page = book.Page,
                        Url_cover = book.Url_cover,
                        Category = book.Category,
                        Keywords = book.Keywords,
                        Added_time = book.Added_time,
                        At_page = 0,
                        Last_readtime = DateTime.Now,
                        // Finish_reading =0

                    };

                    await _libraryService.AddToLibraryAsync(libraryUser);
                    await Shell.Current.GoToAsync(nameof(BooksPage));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item");
                Debug.WriteLine(ex.Message);
            }

        }

        //private async Task OnDeleteBook()
        //{
        //    var result = await UserDialogs.Instance.ConfirmAsync("Are you sure to delete this book ?", "Confirm Selection", "Yes", "No");
        //    Debug.WriteLine(result);
        //}




    }
}
