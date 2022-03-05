using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO.Models
{
    public class Book
    {
        [JsonPropertyName("id_book")]
        public string Id_book { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("description_book")]
        public string Description_book { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("url_cover")]
        public string Url_cover { get; set; }

        [JsonPropertyName("author_names")]
        public string Author_names { get; set; }


    }
}
