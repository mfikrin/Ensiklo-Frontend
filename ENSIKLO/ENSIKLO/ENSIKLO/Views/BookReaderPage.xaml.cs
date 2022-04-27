using ENSIKLO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(AtPage), nameof(AtPage))]
    [QueryProperty(nameof(ContentURL), nameof(ContentURL))]
    public partial class BookReaderPage : ContentPage
    {
        public Stream pdfDocumentStream;
        public int at_page;
        public string content_url;
        public string book_id;
        public int AtPage
        {
            get => at_page;
            set
            {
                at_page = value;
                LoadFromURL();
            } 
        }

        public string ContentURL
        {
            get => content_url;
            set
            {
                content_url = value;                
                LoadFromURL();
            }
        }

        public string BookId
        {
            get => book_id;
            set
            {
                book_id = value;
            }
        }
        public BookReaderPage()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<BookReaderViewModel>();
        }

        async void LoadFromURL()
        {
            if (string.IsNullOrEmpty(content_url) || at_page == 0) return;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(content_url);
            pdfDocumentStream = await response.Content.ReadAsStreamAsync();
            pdfViewerControl.LoadDocument(pdfDocumentStream);
            pdfViewerControl.GoToPage(at_page);
        }

        private void PageChanged(object sender, Syncfusion.SfPdfViewer.XForms.PageChangedEventArgs args)
        {
            at_page = args.NewPageNumber;
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("..");
        }
    }
}