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
    public partial class SearchLibraryPage : ContentPage
    {
        private readonly SearchLibraryViewModel _searchLibraryViewModel;

        public SearchLibraryPage()
        {
            InitializeComponent();
            _searchLibraryViewModel = Startup.Resolve<SearchLibraryViewModel>();
            BindingContext = _searchLibraryViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}