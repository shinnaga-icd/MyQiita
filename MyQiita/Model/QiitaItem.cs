using System;
using Newtonsoft.Json;

namespace MyQiita.Model
{
    public class QiitaItem
    {
        string _id, _title, _url;

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

    }
}
