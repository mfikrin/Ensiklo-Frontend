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
    public class UpdateProfileViewModel : BaseViewModel
    {
        private readonly IUserService _userService; // nanti ganti jadi service buat register dan login
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public string email;
        public string password;
        public string confirmation_password;
        public string username;
        public UpdateProfileViewModel(IUserService userService)
        {
            _userService = userService;
            email = CurrentUser.Email;
            username = CurrentUser.Username;

            SaveCommand = new Command(async () => await OnSave(), ValidateInput);

            //TappedCommand = new Command(onTapped);
            CancelCommand = new Command(OnCancel);

            PropertyChanged +=
            (_, __) => SaveCommand.ChangeCanExecute();
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

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string ConfirmationPassword
        {
            get => confirmation_password;
            set => SetProperty(ref confirmation_password, value);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            Debug.WriteLine("Oncancel");
            await Shell.Current.GoToAsync("//main/profile");
        }

        private async Task OnSave()
        {
            if (ismatchPassword())
            {
                try
                {
                    var user = new User
                    {
                        Username = username,
                        Email = email,
                        Password = password,
                        //Role = "user"

                    };

                    await _userService.UpdateUserAsync(user);

                    User gotuser = await _userService.GetCurrentUser();

                    CurrentUser.Id = gotuser.Id;
                    CurrentUser.Email = gotuser.Email;
                    CurrentUser.Username = gotuser.Username;
                    //CurrentUser.Role = gotuser.Role;

                    Debug.WriteLine("Finished updating profile");
                    Debug.WriteLine(CurrentUser.Username);

                    Debug.WriteLine("Onsave");
                    await Shell.Current.GoToAsync("//main/profile");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("Salah password");
                await App.Current.MainPage.DisplayAlert("Register Failed", "Password doesn't match", "OK");
            }
            // This will pop the current page off the navigation stack

        }

        private bool ValidateInput()
        {
            return !String.IsNullOrWhiteSpace(username)
               && !String.IsNullOrWhiteSpace(email)
               && !String.IsNullOrWhiteSpace(password)
               && !String.IsNullOrWhiteSpace(confirmation_password)
               ;
        }

        private bool ismatchPassword()
        {
            // isPasswordSame
            return password.Equals(confirmation_password);

        }
    }
}
