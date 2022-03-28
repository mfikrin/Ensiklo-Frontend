﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSIKLO.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<RegisterViewModel>();
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var loggedIn = true;
        //    if (loggedIn)
        //    {
        //        Debug.WriteLine("Sudah pernah login in register page");
        //        await Shell.Current.GoToAsync("//main");
        //    }
        //}
    }
}