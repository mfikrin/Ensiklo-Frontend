using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ENSIKLO.ViewModels
{
    public class BookReaderViewModel : BaseViewModel
    {
        public BookReaderViewModel()
        {
        }

        public ICommand BackCommand => new Command(() => Debug.WriteLine("Back gannnnnnnnnnnnnnnnnnnnnnnnn"));
    }
}
