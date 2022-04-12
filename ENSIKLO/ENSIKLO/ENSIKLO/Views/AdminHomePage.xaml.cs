﻿using ENSIKLO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminHomePage : ContentPage
    {
        private readonly AdminPageViewModel _adminPageViewModel;
        public AdminHomePage()
        {
            InitializeComponent();
            _adminPageViewModel = Startup.Resolve<AdminPageViewModel>();
            BindingContext = _adminPageViewModel;
            _adminPageViewModel.GetDatas();
        }
    }
}