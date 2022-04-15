using ENSIKLO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryPage : ContentPage
    {
        private readonly LibraryViewModel _libraryViewModel;
 
        public LibraryPage()
        {
            InitializeComponent();
            _libraryViewModel = Startup.Resolve<LibraryViewModel>();
            BindingContext = _libraryViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _libraryViewModel.OnAppearing();
            _libraryViewModel?.PopulateBooks();
        }
    }
}