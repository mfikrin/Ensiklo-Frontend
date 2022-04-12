using ENSIKLO.Services;
using ENSIKLO.Models;
using ENSIKLO.Views;
using System;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ENSIKLO.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService; // nanti ganti jadi service buat register dan login
        public Command LoginCommand { get; }

        public Command TappedCommand { get; }

        public string email;
        public string password;
        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
            LoginCommand = new Command(async () => await OnLoginClicked(), ValidateLogin);

            TappedCommand = new Command(onTapped);

            PropertyChanged +=
            (_, __) => LoginCommand.ChangeCanExecute();
        }


        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async Task OnLoginClicked()
        {
            try
            {
                Debug.WriteLine(email);
                Debug.WriteLine(!String.IsNullOrWhiteSpace(email));
                Debug.WriteLine(password);
                Debug.WriteLine(!String.IsNullOrWhiteSpace(password));
                Debug.WriteLine("Doing login");
                var req = new LoginRequest
                {
                    Email = email,
                    Password = password,
                };

                string token = await _userService.LoginAsync(req);

                Debug.WriteLine(token);

                CurrentUser.Token = token;

                User gotuser = await _userService.GetCurrentUser();

                CurrentUser.Id = gotuser.Id;
                CurrentUser.Email = gotuser.Email;
                CurrentUser.Username = gotuser.Username;
                CurrentUser.Role = gotuser.Role;

                Debug.WriteLine(gotuser.Email);
                Debug.WriteLine("token = " + CurrentUser.Token);
                Debug.WriteLine("username = " + CurrentUser.Username);

                await Shell.Current.GoToAsync("//main/home");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            // NANTI UNCOMMENT INI

            //if (role.Equals("Admin"){
            //    await Shell.Current.GoToAsync($"//admin/homeAdmin");
            //}
            //else if (role.Equals("User"))
            //{
            //    await Shell.Current.GoToAsync($"//main/home");
            //}

            //await Shell.Current.GoToAsync($"//main/home");
            //await Shell.Current.GoToAsync($"//admin/homeAdmin");

        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//register");
        }
        private bool ValidateLogin()
        {
            return !String.IsNullOrWhiteSpace(email)
               && !String.IsNullOrWhiteSpace(password)
               ;
        }
    }
}
