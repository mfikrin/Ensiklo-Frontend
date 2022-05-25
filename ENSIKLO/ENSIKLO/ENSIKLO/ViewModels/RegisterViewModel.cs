﻿using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        public Command SignUpCommand { get; }

        public Command TappedCommand { get; }


        public string username;
        public string email;
        public string password;
        public string confirmation_password;

        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;

            //SignUpCommand = new Command(OnClickSignUp);

            SignUpCommand = new Command(async () => await OnClickSignUp(), ValidateRegister);

            TappedCommand = new Command(onTapped);

            PropertyChanged +=
            (_, __) => SignUpCommand.ChangeCanExecute();

        }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
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

        public string ConfirmationPassword
        {
            get => confirmation_password;
            set => SetProperty(ref confirmation_password, value);
        }
        private async Task OnClickSignUp()
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
                    };

                    await _userService.AddUserAsync(user);

                    await Shell.Current.GoToAsync("//login");

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


        }


        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//login");
        }

        private bool ValidateRegister()
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

        public void OnAppearing()
        {
            Username = "";
            Email = "";
            Password = "";
            ConfirmationPassword = "";
        }
    }
}
