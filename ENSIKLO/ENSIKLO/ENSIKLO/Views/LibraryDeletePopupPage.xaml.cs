using ENSIKLO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ENSIKLO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryDeletePopupPage : ContentPage
    {
        public LibraryDeletePopupPage()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<LibraryDeletePopupViewModel>();
        }
    }
}