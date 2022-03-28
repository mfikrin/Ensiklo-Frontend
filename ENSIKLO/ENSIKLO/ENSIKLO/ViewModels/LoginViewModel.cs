﻿using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IBookService _bookService; // nanti ganti jadi service buat register dan login
        public Command LoginCommand { get; }

        public Command TappedCommand { get; }

        public LoginViewModel(IBookService bookService)
        {
            _bookService = bookService;
            LoginCommand = new Command(OnLoginClicked);

            TappedCommand = new Command(onTapped);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//main/home");
        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync($"//register");
        }
    }
}
