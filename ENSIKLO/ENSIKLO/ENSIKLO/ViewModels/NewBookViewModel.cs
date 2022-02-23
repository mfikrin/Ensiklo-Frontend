using ENSIKLO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class NewBookViewModel : BaseViewModel
    {
        private string title;
        private int rating;
        private string description_book;
        private int pages;
        private string publisher;
        private string url_cover;
        private string author_names;

        public NewBookViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(rating.ToString())
                && !String.IsNullOrWhiteSpace(description_book)
                && !String.IsNullOrWhiteSpace(pages.ToString())
                && !String.IsNullOrWhiteSpace(publisher)
                && !String.IsNullOrWhiteSpace(url_cover)
                && !String.IsNullOrWhiteSpace(author_names)
                ;
            //return true;
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Book newItem = new Book()
            {
                Id_book="BOOOOKKK",
                Title = Title,
                Description_book = Description_book,
                Publisher = Publisher,
                Url_cover = Url_cover,
                Author_names = Author_names,


            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}