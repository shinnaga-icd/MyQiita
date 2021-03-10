using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyQiita.Model;
using MyQiita.Common;
using AngleSharp;
using Newtonsoft.Json;

namespace MyQiita.Service
{
    public class ScrapingService
    {
        public ScrapingService()
        {
        }
        
        public async Task<List<QiitaScrapingItem>> GetQiitaTrends()
        {
            List<QiitaScrapingItem> items = new List<QiitaScrapingItem>();
            string selector = "div.p-home_container script.js-react-on-rails-component";

            try
            {
                //scraping
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(Constants.QiitaEndPoint);
                var cells = document.QuerySelector(selector);

                //Json Convert
                items = JsonConvert.DeserializeObject<List<QiitaScrapingItem>>(cells.TextContent);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return items;
        }
    }
}
