using System;
using Newtonsoft.Json;

namespace MyQiita.Model
{
    public class QiitaScrapingItem : QiitaItem
    {
        [JsonProperty("uuid")]
        public override string id { get; set; }

        [JsonProperty("title")]
        public override string title { get; set; }

        [JsonProperty("linkUrl")]
        public override string url { get; set; }

        [JsonProperty("likesCount")]
        public override int likesCount { get; set; }

    }
}
