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
    public partial class CatalogPage : ContentPage
    {
        private readonly CatalogViewModel _catalogViewModel;
        public CatalogPage()
        {
            InitializeComponent();
            _catalogViewModel = Startup.Resolve<CatalogViewModel>();
            BindingContext = _catalogViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _catalogViewModel.OnAppearing();
            _catalogViewModel?.PopulateBooks();
        }
    }
}