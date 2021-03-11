using System;
using System.Collections.Generic;

namespace MyQiita.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class QiitaScrapingItem
    {
        public class Author
        {
            public string displayName { get; set; }
            public bool isUser { get; set; }
            public string linkUrl { get; set; }
            public string profileImageUrl { get; set; }
            public string urlName { get; set; }
        }

        public class Tag
        {
            public string urlName { get; set; }
            public string name { get; set; }
        }

        public class Node
        {
            public string encryptedId { get; set; }
            public bool isLikedByViewer { get; set; }
            public bool isStockableByViewer { get; set; }
            public bool isStockedByViewer { get; set; }
            public int likesCount { get; set; }
            public string linkUrl { get; set; }
            public DateTime publishedAt { get; set; }
            public string title { get; set; }
            public string uuid { get; set; }
            public Author author { get; set; }
            public List<object> recentlyFollowingLikers { get; set; }
            public List<Tag> tags { get; set; }
        }

        public class Edge
        {
            public bool hasCodeBlock { get; set; }
            public bool isLikedByViewer { get; set; }
            public bool isNewArrival { get; set; }
            public List<object> followingLikers { get; set; }
            public Node node { get; set; }
        }

        public class Trend
        {
            public List<Edge> edges { get; set; }
        }

        public class Root
        {
            public Trend trend { get; set; }
        }

        //property
        public Root root { get; set; }

    }
}
