using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        public Command LogoutCommand { get; }
        public string email;
        public string userName;
        public Int64 id;


        public ProfileViewModel(IBookService bookService, IUserService userService)
        {

            _userService = userService;
            _bookService = bookService;

            LogoutCommand = new Command(OnClickLogout);


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




    }
}
