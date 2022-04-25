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
    public partial class BooksFromAuthorPage : ContentPage
    {
        private readonly BooksFromAuthorViewModel _booksFromAuthorViewModel;
        public BooksFromAuthorPage()
        {
            InitializeComponent();
            _booksFromAuthorViewModel = Startup.Resolve<BooksFromAuthorViewModel>();
            BindingContext = _booksFromAuthorViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _booksFromAuthorViewModel.OnAppearing();
            _booksFromAuthorViewModel?.PopulateBooks();
        }
    }
}