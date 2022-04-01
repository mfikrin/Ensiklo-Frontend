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
        private readonly IBookService _bookService; // nanti ganti jadi service buat register dan login
        public Command SignUpCommand { get; }

        public Command TappedCommand { get; }

        public RegisterViewModel(IBookService bookService)
        {
           

            _bookService = bookService;

            SignUpCommand = new Command(OnClickSignUp);

            TappedCommand = new Command(onTapped);
        }

        private async void OnClickSignUp(object obj)
        {
            await Shell.Current.GoToAsync("//main/home");
        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync($"//login");
        }

    }
}
