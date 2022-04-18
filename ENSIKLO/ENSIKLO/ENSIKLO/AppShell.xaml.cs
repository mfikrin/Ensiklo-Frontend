using ENSIKLO.ViewModels;
using ENSIKLO.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ENSIKLO
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
            Routing.RegisterRoute(nameof(BooksPage), typeof(BooksPage));
            Routing.RegisterRoute(nameof(NewArrivalBooksPage), typeof(NewArrivalBooksPage));
            Routing.RegisterRoute(nameof(SearchResultPage), typeof(SearchResultPage));
        }

    }
}
