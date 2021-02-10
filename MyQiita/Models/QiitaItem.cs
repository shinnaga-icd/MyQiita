using System;
using Newtonsoft.Json;

namespace MyQiita.Models
{
    public class QiitaItem
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
