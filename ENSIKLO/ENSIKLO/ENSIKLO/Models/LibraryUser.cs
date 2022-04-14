using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO.Models
{
    public class LibraryUser
    {
        [JsonPropertyName("id_user")]
        public int Id_user { get; set; }
        [JsonPropertyName("id_book")]
        public int Id_book { get; set; }
        [JsonPropertyName("at_page")]
        public int At_page { get; set; }
        [JsonPropertyName("last_readtime")]
        public DateTime Last_readtime { get; set; }
    }
}
