using ENSIKLO.Models;
using ENSIKLO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(AtPage), nameof(AtPage))]
    [QueryProperty(nameof(ContentURL), nameof(ContentURL))]
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public partial class BookReaderPage : ContentPage
    {
        public Stream pdfDocumentStream;
        public int at_page;
        public string content_url;
        public string book_id;
        public int current_page;
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
            Debug.WriteLine(content_url);
            Debug.WriteLine(at_page);
            Debug.WriteLine(current_page);
            current_page = at_page;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(content_url);
            pdfDocumentStream = await response.Content.ReadAsStreamAsync();
            pdfViewerControl.LoadDocument(pdfDocumentStream);
            pdfViewerControl.GoToPage(at_page);
            Debug.WriteLine("done loading --------");
        }

        private void PageChanged(object sender, Syncfusion.SfPdfViewer.XForms.PageChangedEventArgs args)
        {
            Debug.Write("current_page update");
            current_page = args.NewPageNumber;
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            Debug.WriteLine($"http://localhost:5223/api/LibraryUser/update/{CurrentUser.Id}/{book_id}/{current_page}");
            var response = await httpClient.PostAsync($"http://localhost:5223/api/LibraryUser/update/{CurrentUser.Id}/{book_id}/{current_page}", new StringContent(JsonSerializer.Serialize(""), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            await Shell.Current.GoToAsync($"{nameof(LibraryPage)}");
        }
    }
}