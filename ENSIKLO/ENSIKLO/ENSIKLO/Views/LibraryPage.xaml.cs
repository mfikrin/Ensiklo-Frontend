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
        private readonly BookViewModel _booksViewModel;
        public LibraryPage()
        {
            InitializeComponent();
            _booksViewModel = Startup.Resolve<BookViewModel>();
            BindingContext = _booksViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _booksViewModel.OnAppearing();
            _booksViewModel?.PopulateBooks();
        }
    }
}

