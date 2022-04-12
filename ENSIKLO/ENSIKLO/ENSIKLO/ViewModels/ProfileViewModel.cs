using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IUserService _userService; // nanti ganti jadi service buat register dan login
        public Command LogoutCommand { get; }
        public string email;
        public string userName;

        public ProfileViewModel(IUserService userService)
        {
            _userService = userService;
            LogoutCommand = new Command(OnClickLogout);
        }

        private async void OnClickLogout(object obj)
        {
            await Shell.Current.GoToAsync($"//login");
        }

        public async void GetData()
        {
            var user = await _userService.GetCurrentUser();
            //email = ((App)App.Current).currUser.Email;
            //userName = ((App)App.Current).currUser.Username;
            email = user.Email;
            userName = user.Username;
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


    }
}
