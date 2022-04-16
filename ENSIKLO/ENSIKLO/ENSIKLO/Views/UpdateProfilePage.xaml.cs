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
    public partial class UpdateProfilePage : ContentPage
    {
        private readonly UpdateProfileViewModel _updateProfileViewModel;
        public UpdateProfilePage()
        {
            InitializeComponent();
            _updateProfileViewModel = Startup.Resolve<UpdateProfileViewModel>();
            BindingContext = _updateProfileViewModel;
        }
    }
}