using System;
using System.Collections.Generic;

namespace MyQiita.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class QiitaRestItem
    {
        public class Group
        {
            public DateTime created_at { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public bool @private { get; set; }
            public DateTime updated_at { get; set; }
            public string url_name { get; set; }
        }

        public class Tag
        {
            public string name { get; set; }
            public List<string> versions { get; set; }
        }

        public class User
        {
            public string description { get; set; }
            public string facebook_id { get; set; }
            public int followees_count { get; set; }
            public int followers_count { get; set; }
            public string github_login_name { get; set; }
            public string id { get; set; }
            public int items_count { get; set; }
            public string linkedin_id { get; set; }
            public string location { get; set; }
            public string name { get; set; }
            public string organization { get; set; }
            public int permanent_id { get; set; }
            public string profile_image_url { get; set; }
            public bool team_only { get; set; }
            public string twitter_screen_name { get; set; }
            public string website_url { get; set; }
        }

        public class Root
        {
            public string rendered_body { get; set; }
            public string body { get; set; }
            public bool coediting { get; set; }
            public int comments_count { get; set; }
            public DateTime created_at { get; set; }
            public Group group { get; set; }
            public string id { get; set; }
            public int likes_count { get; set; }
            public bool @private { get; set; }
            public int reactions_count { get; set; }
            public List<Tag> tags { get; set; }
            public string title { get; set; }
            public DateTime updated_at { get; set; }
            public string url { get; set; }
            public User user { get; set; }
            public int page_views_count { get; set; }
        }

        //property
        public Root root { get; set; }

        public QiitaItem QiitaItem
        {
            get
            {
                return root == null ?
                    new QiitaItem()
                  : new QiitaItem(id: root.id,
                                  title: root.title,
                                  url: root.url,
                                  likesCount: root.likes_count);
            }
        }
    }
}
