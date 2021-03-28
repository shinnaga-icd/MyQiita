using System;
namespace MyQiita.Common
{
    public static class Constants
    {

        /// <summary>
        /// Qiita EndPoint
        /// </summary>
        public const string QiitaUrl = "https://qiita.com";

        /// <summary>
        /// Qiita API EndPoint
        /// </summary>
        public const string QiitaApiUrl = "https://qiita.com/api";

        /// <summary>
        /// Qiita Trend Selector
        /// </summary>
        public const string ScrapingSelectorQiitaTrend = "div.p-home_container script.js-react-on-rails-component";

        /// <summary>
        /// Qiita URL OAuth
        /// </summary>
        public const string QiitaOauthUrl = "http://qiita.com/api/v2/oauth/authorize";

        /// <summary>
        /// Qiita URL CallBack
        /// </summary>
        public const string QiitaCallBackUrl = "myqiita://oauth";

        /// <summary>
        /// Qiita URL Redirect
        /// </summary>
        public const string QiitaRedirectUrl = "https://qiita.com/api/v2/access_tokens";

        /// <summary>
        /// Qiita Oauth ClientID
        /// </summary>
        public const string QiitaOauthClientID = "805367f8e745b14255988e05f0f85da4f790b931";

        /// <summary>
        /// Qiita Oauth ClientSecret
        /// </summary>
        public const string QiitaOauthClientSecret = "b868bc7b004ddbbfc4a7290a55f4eeac559226f3";
    }
}
