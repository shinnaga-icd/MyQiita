using System;
using Newtonsoft.Json;

namespace MyQiita.Model
{
    public class QiitaItem
    {
        public virtual string id { get; set; }

        public virtual string title { get; set; }

        public virtual string url { get; set; }

        public virtual int likesCount { get; set; }
    }
}
