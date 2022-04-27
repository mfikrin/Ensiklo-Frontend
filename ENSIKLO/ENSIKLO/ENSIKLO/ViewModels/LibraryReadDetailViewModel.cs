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
    [QueryProperty(nameof(AtPage), nameof(AtPage))]
    public class LibraryReadDetailViewModel : BaseViewModel
    {

        private string id_book;

        private string title;

        private string author;

        private string publisher;

        private DateTime year_published;

        private string description_book;

        private string book_content;

        private string url_cover;

        private string category;

        private string keywords;

        private int at_page;

        private readonly ILibraryService _libraryService;
        public Command RemoveFromLibraryCommand { get; }
        public Command ReadBookCommand { get; }
        public Command PublisherTappedCommand { get; }
        public Command AuthorTappedCommand { get; }
        public LibraryReadDetailViewModel(ILibraryService libraryService)
        {
            _libraryService = libraryService;

            RemoveFromLibraryCommand = new Command(async bookid => await OnRemoveBook(userid: Convert.ToInt32(CurrentUser.Id), bookid: BookId));
            ReadBookCommand = new Command(async () => await OnReadBook());
            PublisherTappedCommand = new Command(async publishername => await onPublisherTapped(publisher_name: Publisher));
            AuthorTappedCommand = new Command(async authorname => await onAuthorTapped(author_name: Author));
        }

        private async Task onPublisherTapped(string publisher_name)
        {
            //await Shell.Current.GoToAsync(nameof(BooksFromPublisherPage));
            await Shell.Current.GoToAsync($"{nameof(BooksFromPublisherPage)}?{nameof(BooksFromPublisherViewModel.PublisherName)}={publisher_name}");
        }

        private async Task onAuthorTapped(string author_name)
        {
            await Shell.Current.GoToAsync($"{nameof(BooksFromAuthorPage)}?{nameof(BooksFromAuthorViewModel.AuthorName)}={author_name}");
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
                LoadBookId(Convert.ToInt32(CurrentUser.Id), id_book);

            }
        }

        public int AtPage
        {
            get => at_page;
            set
            {
                SetProperty(ref at_page, value);
            }
        }

        public async void LoadBookId(int userId, string bookId)
        {
            try
            {                
                var book = await _libraryService.GetLibraryItemAsync(userId, int.Parse(bookId));
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

        private async Task OnRemoveBook(int userid, string bookid)
        {
            await _libraryService.DeleteFromLibraryAsync(Convert.ToInt32(CurrentUser.Id), int.Parse(bookid));
            //await Shell.Current.Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync(nameof(LibraryPage));
            await App.Current.MainPage.DisplayAlert("Removed Book", "The book has been removed from the library", "OK");
            await Shell.Current.GoToAsync(nameof(LibraryPage));
            //await Shell.Current.GoToAsync("..");





        }

        private async Task OnReadBook()
        {          
            await Shell.Current.GoToAsync($"//book-reader?{nameof(BookReaderPage.AtPage)}={AtPage}&{nameof(BookReaderPage.ContentURL)}={Book_content}&{nameof(BookReaderPage.BookId)}={id_book}");
        }
    }
}
