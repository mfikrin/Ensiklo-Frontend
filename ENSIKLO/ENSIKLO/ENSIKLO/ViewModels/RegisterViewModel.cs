using ENSIKLO.Models;
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
        public string role;

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

        public string Role
        {
            get => role;
            set => SetProperty(ref role, value);
        }

        private async Task OnClickSignUp()
        {
            try
            {

                //role = "user";
                var user = new User
                {
                    Username = username,
                    Email = email,
                    Password = password,
                    Role = role

                };

                await _userService.AddUserAsync(user);

                if (user.Role == "user")
                {
                    await Shell.Current.GoToAsync("//main/home");
                }
                else if (user.Role == "admin")
                {
                    await Shell.Current.GoToAsync($"//admin/homeAdmin");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
               && !String.IsNullOrWhiteSpace(role)
               ;
        }
    }
}
