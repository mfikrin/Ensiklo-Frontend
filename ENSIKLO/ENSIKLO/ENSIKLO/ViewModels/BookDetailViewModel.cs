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
        private string bookId;
        private string title;
        private int rating;
        private string description_book;
        private int pages;
        private string publisher;
        private string url_cover;
        private string author_names;

        public string Id { get; set; }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public int Rating
        {
            get => rating;
            set => SetProperty(ref rating, value);
        }

        public string Description_book
        {
            get => description_book;
            set => SetProperty(ref description_book, value);
        }

        public int Pages
        {
            get => pages;
            set => SetProperty(ref pages, value);
        }

        public string Publisher
        {
            get => publisher;
            set => SetProperty(ref publisher, value);
        }

        public string Url_cover
        {
            get => url_cover;
            set => SetProperty(ref url_cover, value);
        }

        public string Author_names
        {
            get => author_names;
            set => SetProperty(ref author_names, value);
        }

        public string BookId
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
                LoadBookId(value);
            }
        }

        public async void LoadBookId(string bookId)
        {
            try
            {
                var book = await DataStore.GetItemAsync(bookId);
                Id = book.Id_book;
                Title = book.Title;
                Description_book = book.Description_book;
                Publisher = book.Publisher;
                Url_cover = book.Url_cover;
                Author_names = book.Author_names;     
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }




    }
}
