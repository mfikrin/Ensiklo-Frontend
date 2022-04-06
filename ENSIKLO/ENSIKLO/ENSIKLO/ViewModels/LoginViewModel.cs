using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        public Command LoginCommand { get; }

        public Command TappedCommand { get; }

        public IUserService UserServiceLogin { get; }

        public LoginViewModel(IUserService userService)
        {
            UserServiceLogin = userService;
            LoginCommand = new Command(OnLoginClicked);

            TappedCommand = new Command(onTapped);
        }

        private async void OnLoginClicked()
        {
 
            await Shell.Current.GoToAsync("//main/home");
            

        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//register");
        }
    }
}
