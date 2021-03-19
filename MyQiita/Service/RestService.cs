using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using MyQiita.Model;

namespace MyQiita.Service
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<QiitaRestItem>> GetQiitaItemsAsync(string uri)
        {
            List<QiitaRestItem> qiitaRestItem = new List<QiitaRestItem>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var arrayItem = JsonConvert.DeserializeObject<QiitaRestItem[]>(content);

                    qiitaRestItem = arrayItem.ToList();
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return qiitaRestItem;
        }
    }
}
