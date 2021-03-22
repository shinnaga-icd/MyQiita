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
        public async Task<QiitaScrapingItem> GetQiitaTrends()
        {
            QiitaScrapingItem qiitaScrapingItem = new QiitaScrapingItem();
            string selector = Constants.ScrapingSelectorQiitaTrend;

            try
            {
                //scraping
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(Constants.QiitaEndPoint);
                var cells = document.QuerySelector(selector);

                //Json Convert
                qiitaScrapingItem.root = JsonConvert.DeserializeObject<QiitaScrapingItem.Root>(cells.TextContent);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return qiitaScrapingItem;
        }
    }
}
