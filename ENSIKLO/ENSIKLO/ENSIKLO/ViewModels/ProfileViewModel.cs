using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IBookService _bookService; // nanti ganti jadi service buat register dan login
        public Command LogoutCommand { get; }

        public ProfileViewModel(IBookService bookService)
        {


            _bookService = bookService;

            LogoutCommand = new Command(OnClickLogout);

            
        }

        private async void OnClickLogout(object obj)
        {
            await Shell.Current.GoToAsync($"//login");
        }
    }
}
