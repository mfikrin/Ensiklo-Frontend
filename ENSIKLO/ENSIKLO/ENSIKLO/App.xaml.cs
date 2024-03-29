using ENSIKLO.Models;
using ENSIKLO.Services;
using ENSIKLO.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQ2MjIxQDMyMzAyZTMxMmUzMGV2ejJ3Y2ozNElyS2FCOUsxVWFQbFNtYjgyanZtZENxUlgvOTIxMlpKemc9");

            InitializeComponent();

            Startup.ConfigureServices();

            //DependencyService.Register<DummyBookStore>();
            MainPage = new AppShell();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
