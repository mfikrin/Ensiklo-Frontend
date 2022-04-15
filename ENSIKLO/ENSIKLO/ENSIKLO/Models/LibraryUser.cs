using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO.Models
{
    public class LibraryUser
    {
        [JsonPropertyName("id_book")]
        public int Id_book { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("year_published")]
        public DateTime Year_published { get; set; }

        [JsonPropertyName("description_book")]
        public string Description_book { get; set; }

        [JsonPropertyName("book_content")]
        public string Book_content { get; set; }

        [JsonPropertyName("url_cover")]
        public string Url_cover { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }
        [JsonPropertyName("added_time")]
        public DateTime Added_time { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("id_user")]
        public int Id_user { get; set; }

        [JsonPropertyName("at_page")]
        public int At_page { get; set; }
        [JsonPropertyName("last_readtime")]
        public DateTime Last_readtime { get; set; }
        /* [JsonPropertyName("finish_reading")]
        public int Finish_reading { get; set; } */
    }
}
