using ENSIKLO.Services;
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
    
        private int id_book ;

        private string title ;

        private string author ;

        private string publisher ;

        private string year_published ;

        private string description_book ;

        private string book_content ;

        private string url_cover ;

        private string category ;

        private string keywords ;

        private readonly IBookService _bookService;

        public BookDetailViewModel(IBookService bookService)
        {
            _bookService = bookService;

            //SaveBookCommand = new Command(async () => await SaveBook());
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

        public string Year_published
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


        public int BookId
        {
            get
            {
                return id_book;
            }
            set
            {
                id_book = value;
                LoadBookId(value);
            }
        }

        public async void LoadBookId(int bookId)
        {
            try
            {
                var book = await _bookService.GetItemAsync(bookId);
                Id = book.id_book;
                Title = book.title;
                Author = book.author;
                Publisher = book.publisher;
                Year_published = book.year_published;
                Description_book = book.description_book;
                Book_content = book.book_content;
                Url_cover = book.url_cover;
                Category = book.category;
                Keywords = book.keywords;  
               
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }




    }
}
