using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService; // nanti ganti jadi service buat register dan login
        public Command LoginCommand { get; }

        public Command TappedCommand { get; }

        public string email;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
            LoginCommand = new Command<string>(OnLoginClicked);

            TappedCommand = new Command(onTapped);
        }

        private async void OnLoginClicked(string role)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            // NANTI UNCOMMENT INI

            //if (role.Equals("Admin"){
            //    await Shell.Current.GoToAsync($"//admin/homeAdmin");
            //}
            //else if (role.Equals("User"))
            //{
            //    await Shell.Current.GoToAsync($"//main/home");
            //}



            await Shell.Current.GoToAsync("//admin/homeAdmin");
            //await Shell.Current.GoToAsync($"//main/home");
            //await Shell.Current.GoToAsync($"//admin/homeAdmin");

            //Debug.WriteLine(await _userService.GetUserID(email));
            ((App)App.Current).userID = await _userService.GetUserID(email);

        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//register");
        }
    }
}
