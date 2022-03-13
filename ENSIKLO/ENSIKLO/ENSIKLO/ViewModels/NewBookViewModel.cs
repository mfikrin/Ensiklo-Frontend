using ENSIKLO.Models;
using ENSIKLO.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class NewBookViewModel : BaseViewModel
    {
        public int id_book;

        public string title;

        public string author;

        public string publisher;

        public string year_published;

        public string description_book;

        public string book_content;

        public string url_cover;

        public string category;

        public string keywords;

        private readonly IBookService _bookService;

        public NewBookViewModel(IBookService bookService)
        {
            _bookService = bookService;
            SaveCommand = new Command(async () => await OnSave(), ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(author)
                && !String.IsNullOrWhiteSpace(publisher)
                && !String.IsNullOrWhiteSpace(year_published)
                && !String.IsNullOrWhiteSpace(description_book)
                && !String.IsNullOrWhiteSpace(book_content)
                && !String.IsNullOrWhiteSpace(url_cover)
                && !String.IsNullOrWhiteSpace(category)
                && !String.IsNullOrWhiteSpace(keywords)
                ;
            //return true;
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async Task OnSave()
        {
            try
            {
                var book = new Book
                {
             
                    Title = Title,
                    Author = Author,
                    Publisher = Publisher,
                    Year_published = Year_published,
                    Description_book = Description_book,
                    Book_content = Book_content,
                    Url_cover = Url_cover,
                    Category = Category,
                    Keywords = Keywords
                };

                await _bookService.AddItemAsync(book);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}