using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyQiita.Model;
using MyQiita.Service;

namespace MyQiita.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string QiitaEndpoint = "https://qiita.com/api/v2/items?page=1&per_page=20";

        private List<QiitaItem> qiitaItems;
        public List<QiitaItem> QiitaItems
        {
            get { return qiitaItems; }
            set { SetProperty<List<QiitaItem>>(ref qiitaItems, value); }
        }


        public MainViewModel()
        {
            SetQiitaItems();
        }

        async private void SetQiitaItems()
        {
            RestService restService = new RestService();
            List<QiitaItem> items = await restService.GetQiitaItemsAsync(QiitaEndpoint);
            QiitaItems = items;
        }

    }
}
