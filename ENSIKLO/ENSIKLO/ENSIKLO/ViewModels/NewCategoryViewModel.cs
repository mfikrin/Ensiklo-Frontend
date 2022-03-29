using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class NewCategoryViewModel
    {
        public NewCategoryViewModel()
        {
            //SaveCommand = new Command(async () => await OnSave(), ValidateSave);
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            //PropertyChanged +=
            //    (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            // This will pop the current page off the navigation stack
            Console.WriteLine("tambah buku");
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
    }
}
