using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Linq;
using Xamarin.Forms;
using Prism.Events;
using Prism.Commands;
using Prism.Navigation;
using Reactive.Bindings;
using MyQiita.Model;
using MyQiita.Service;
using MyQiita.Navigation;
using MyQiita.Common;

namespace MyQiita.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private const string QiitaEndpoint = Constants.QiitaApiEndpoint + "/v2/items?page=1&per_page=20";

        // Property
        public ReactiveCollection<QiitaItem> QiitaItems { get; set; } = new ReactiveCollection<QiitaItem>();
        public ReactiveProperty<QiitaItem> SelectedItem { get; set; } = new ReactiveProperty<QiitaItem>();
        public ICommand ItemSelectCommand { get; private set; }

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            SetQiitaItems();

            SelectedItem.Where(x => x != null).Subscribe(x =>
            {
                _navigationService.NavigateAsync(Navigate.Item, (NavigateParams.ItemURL, x.url));
            });
        }

        //ListViewにQiitaアイテムをセット
        async private void SetQiitaItems()
        {
            //RestService restService = new RestService();
            //List<QiitaRestItem> items = await restService.GetQiitaItemsAsync(QiitaEndpoint);
            ScrapingService scrapingService = new ScrapingService();
            QiitaScrapingItem item = await scrapingService.GetQiitaTrends();

            item.root.trend.edges.ForEach(x =>
                QiitaItems.Add(new QiitaItem(id: x.node.uuid, title: x.node.title, url: x.node.linkUrl, likesCount: x.node.likesCount)));
        }

    }
}
