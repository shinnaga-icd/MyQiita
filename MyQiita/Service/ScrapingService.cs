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
        public async Task<QiitaScrapingItem> GetQiitaTrends(string address, string selector)
        {
            QiitaScrapingItem _deserializeObject = new();

            try
            {
                //scraping
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(address);
                var cells = document.QuerySelector(selector);

                //Json Convert
                _deserializeObject = JsonConvert.DeserializeObject<QiitaScrapingItem>(cells.TextContent);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return _deserializeObject;
        }
    }
}
