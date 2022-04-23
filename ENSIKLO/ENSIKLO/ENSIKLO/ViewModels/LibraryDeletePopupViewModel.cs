using ENSIKLO.Services;
using ENSIKLO.Models;
using ENSIKLO.Views;
using System;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ENSIKLO.ViewModels
{
    public class LibraryDeletePopupViewModel : BaseViewModel
    {
        public Command BacktoLibraryCommand { get; }

        public LibraryDeletePopupViewModel()
        {
            BacktoLibraryCommand = new Command(OnBtnClicked);
        }

        private async void OnBtnClicked(object obj)
        {
            await Shell.Current.GoToAsync(nameof(LibraryPage));
        }
    }
}
