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

        /// <summary>
        /// QiitaAPIよりQiitaItemsを取得
        /// </summary>
        /// <param name="uri">取得API URL</param>
        /// <returns>QiitaItems</returns>
        /// <remarks>ToDo:QiitaRestItemにList属性を持たせ、Generic型指定をQiitaRestItemのみとさせたい</remarks>
        public async Task<List<QiitaRestItem>> GetQiitaItemsAsync(string uri)
        {
            List<QiitaRestItem> _deserializeObject = new();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    _deserializeObject = JsonConvert.DeserializeObject<List<QiitaRestItem>>(content);

                }
            }catch(Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return _deserializeObject;
        }
    }
}
