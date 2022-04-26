using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO.ViewModels
{
    public class BookReaderViewModel : BaseViewModel
    {
        private Stream m_pdfDocumentStream;

        public Stream PdfDocumentStream
        {
            get { return m_pdfDocumentStream; }
            set
            {
                m_pdfDocumentStream = value;
                SetProperty(ref m_pdfDocumentStream, value);
            }
        }

        public BookReaderViewModel()
        {
            LoadFromUrl();
        }

        async void LoadFromUrl()
        {
            Debug.WriteLine("mulai laoding");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://www.syncfusion.com/downloads/support/directtrac/general/pd/GIS_Succinctly1774404643.pdf");
            PdfDocumentStream = await response.Content.ReadAsStreamAsync();
            Debug.WriteLine("endlaoding-------------------------");
        }
    }
}
