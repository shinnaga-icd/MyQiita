using System;
using System.Collections.Generic;
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

        public async Task<List<QiitaItem>> GetQiitaItemsAsync(string uri)
        {
            List<QiitaItem> items = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<QiitaItem>>(content);
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return items;
        }
    }
}
