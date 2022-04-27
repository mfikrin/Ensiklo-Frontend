using System;
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
        private readonly RegisterViewModel _RegisterViewModel;
        public RegisterPage()
        {
            InitializeComponent();
            _RegisterViewModel = Startup.Resolve<RegisterViewModel>();
            BindingContext = _RegisterViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _RegisterViewModel.OnAppearing();
        }
    }
}