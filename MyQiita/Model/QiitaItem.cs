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

        public string id { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public int likesCount { get; set; }
    }
}
