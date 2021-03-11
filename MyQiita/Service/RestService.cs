using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<QiitaRestItem> GetQiitaItemsAsync(string uri)
        {
            QiitaRestItem qiitaRestItem = new QiitaRestItem();
            try
            {
                
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    qiitaRestItem.root = JsonConvert.DeserializeObject<QiitaRestItem.Root>(content);
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return qiitaRestItem;
        }
    }
}
