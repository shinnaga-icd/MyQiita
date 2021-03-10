using System;
using Newtonsoft.Json;

namespace MyQiita.Model
{
    public class QiitaRestItem : QiitaItem
    {
        [JsonProperty("id")]
        public override string id { get; set; }

        [JsonProperty("title")]
        public override string title { get; set; }

        [JsonProperty("url")]
        public override string url { get; set; }

        [JsonProperty("likes_count")]
        public override int likesCount { get; set; }
    }
}
