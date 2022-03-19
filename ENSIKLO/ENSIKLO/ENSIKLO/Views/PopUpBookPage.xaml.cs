using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ENSIKLO.ViewModels;
using System.Diagnostics;
using ENSIKLO.Models;

namespace ENSIKLO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpBookPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private Book BooksIn;
        public PopUpBookPage(Book param)
        {
            
            InitializeComponent();
            BooksIn = param;
            //Debug.WriteLine(BooksIn);
            //Image img_book = new Image();
            //img_book.Source = BooksIn.Url_cover;
            //BookLayout.Children.Add(img_book);
         


            //BindingContext = Startup.Resolve<PopUpBookPageViewModel>();
        }
    }
}