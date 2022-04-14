using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private readonly ILibraryUserService _libraryUserService;

        public Command LogoutCommand { get; }
        public string email;
        public string userName;
        public Int64 id;

        private ObservableCollection<Book> booksBottom;
        private Book _selectedBook;

        public ProfileViewModel(IUserService userService, IBookService bookService, ILibraryUserService libraryUser)
        {
            _userService = userService;
            LogoutCommand = new Command(OnClickLogout);

            _bookService = bookService;
            booksBottom = new ObservableCollection<Book>();

            _libraryUserService = libraryUser;
        }

        private async void OnClickLogout(object obj)
        {
            await Shell.Current.GoToAsync($"//login");
        }

        public async void GetData()
        {
            //var user = await _userService.GetCurrentUser();
            var user = new User
            {
                Username = "tes nama",
                Email = "tes email",
                Id = 1,
            };
            email = user.Email;
            userName = user.Username;
            id = user.Id;
            Debug.WriteLine(email);
            Debug.WriteLine(userName);
            Email = email;
            Name = userName;
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
            await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.Id_book}");
        }

        public async Task PopulateBooks()
        {
            IsBusy = true;

            try
            {
                BooksBottom.Clear();


                var booksBottomTemp = await _libraryUserService.GetFinishedBooks(id);
                foreach (var book in booksBottomTemp)
                {
                    BooksBottom.Add(await _bookService.GetItemAsync(book));
                    Debug.WriteLine(book);
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

    }
}
