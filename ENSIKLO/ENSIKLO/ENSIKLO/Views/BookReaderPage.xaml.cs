using ENSIKLO.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public int AtPage
        {
            get => at_page;
            set
            {
                // at_page = value;
                at_page = 3;
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
        public BookReaderPage()
        {
            InitializeComponent();
            LoadFromURL();
        }

        async void LoadFromURL()
        {
            if (string.IsNullOrEmpty(content_url) || at_page == 0) return;
            content_url = "https://dwuwgntlmmbscgwycsxt.supabase.co/storage/v1/object/public/test/130564406-Tugas%20Besar%20Arduino%20IF3210%202021_2022.pdf";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(content_url);
            pdfDocumentStream = await response.Content.ReadAsStreamAsync();
            pdfViewerControl.LoadDocument(pdfDocumentStream);
            pdfViewerControl.GoToPage(at_page);
        }
    }
}