using System.Collections.Generic;

namespace MyQiita.Model
{
    public class QiitaItem
    {
        public QiitaItem(string id = "",
                         string title = "",
                         string url = "",
                         int likesCount = 0)
        {
            this.id = id;
            this.title = title;
            this.url = url;
            this.likesCount = likesCount;
        }

        public QiitaItem(QiitaRestItem restItem)
        {
            this.id = restItem.id;
            this.title = restItem.title;
            this.url = restItem.url;
            this.likesCount = restItem.likes_count;
        }

        public QiitaItem(QiitaScrapingItem.Edge scrapingEdgeItem)
        {
            var node = scrapingEdgeItem.node;

            this.id = node.uuid;
            this.title = node.title;
            this.url = node.linkUrl;
            this.likesCount = node.likesCount;
        }

        public string id { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public int likesCount { get; set; }

    }
}
