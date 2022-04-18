using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly ILibraryService _libraryService;
        public Command LogoutCommand { get; }
        public string email;
        public string userName;
        public Int64 id;

        private ObservableCollection<Book> booksBottom;
        private Book _selectedBook;

        public Command UpdateProfile { get; }

        public ProfileViewModel(IBookService bookService, IUserService userService, ILibraryService libraryService)
        {

            _userService = userService;
            _bookService = bookService;
            _libraryService = libraryService;

            LogoutCommand = new Command(OnClickLogout);
            booksBottom = new ObservableCollection<Book>();
            UpdateProfile = new Command(UpdateProfileTapped);

        }

        private async void OnClickLogout(object obj)
        {
            await Shell.Current.GoToAsync($"//login");
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Name
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public async void GetData()
        {
            var user = await _userService.GetCurrentUser();
            //var user = new User
            //{
            //    Username = "tes nama",
            //    Email = "tes email",
            //    Id = 1,
            //};
            email = user.Email;
            userName = user.Username;
            id = user.Id;
            Debug.WriteLine(email);
            Debug.WriteLine(userName);
            Email = email;
            Name = userName;
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

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(LibraryReadDetailPage)}?{nameof(LibraryReadDetailViewModel.BookId)}={book.Id_book}");
        }

        public async Task PopulateBooks()
        {
            IsBusy = true;

            try
            {
                BooksBottom.Clear();

                var user = await _userService.GetCurrentUser();
                id = user.Id;

                var booksBottomTemp = await _libraryService.GetFinishedBooks(id);
                foreach (var book in booksBottomTemp)
                {
                    BooksBottom.Add(await _bookService.GetItemAsync(book));
                    Debug.WriteLine("sukses");
                }

                Debug.WriteLine(BooksBottom.Count);
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

        private async void UpdateProfileTapped(object obj)
        {
            await Shell.Current.GoToAsync(nameof(UpdateProfilePage));
        }

    }
}
