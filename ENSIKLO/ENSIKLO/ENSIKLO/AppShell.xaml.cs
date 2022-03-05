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
            Routing.RegisterRoute(nameof(NewBookPage), typeof(NewBookPage));
        }

    }
}
