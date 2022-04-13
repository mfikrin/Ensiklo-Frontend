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
    public partial class NewArrivalBooksPage : ContentPage
    {
        private readonly NewArrivalViewModel _newArrivalBooksViewModel;
        public NewArrivalBooksPage()
        {
            InitializeComponent();
            _newArrivalBooksViewModel = Startup.Resolve<NewArrivalViewModel>();
            BindingContext = _newArrivalBooksViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _newArrivalBooksViewModel.OnAppearing();
            _newArrivalBooksViewModel?.PopulateBooks();
        }
    }
}