using System;
using System.Windows.Input;
using System.Linq;
using System.Reactive.Linq;
using System.Collections.Generic;
using Prism.Navigation;
using Reactive.Bindings;
using MyQiita.Common;
using MyQiita.Model;
using MyQiita.Service;
using MyQiita.Navigation;

namespace MyQiita.ViewModel
{
    public class ItemListViewModel : ViewModelBase
    {
        public ReactiveCollection<QiitaItem> QiitaItems { get; set; } = new ReactiveCollection<QiitaItem>();
        public ReactiveProperty<QiitaItem> SelectedItem { get; set; } = new ReactiveProperty<QiitaItem>();

        private const string QiitaEndpoint = Constants.QiitaApiEndpoint + "/v2/items?page=1&per_page=20";

        public ItemListViewModel(INavigationService navigationService) : base(navigationService)
        {
            SetQiitaItems();

            SelectedItem.Where(x => x != null).Subscribe(x =>
            {
                _navigationService.NavigateAsync(Navigate.Item, (NavigateParams.ItemURL, x.url));
            });
        }

        /// <summary>
        /// ListViewにQiitaItemをセット
        /// </summary>
        async private void SetQiitaItems()
        {
            RestService restService = new RestService();
            var item = await restService.GetQiitaItemsAsync(QiitaEndpoint);

            item.QiitaItems.ToList().ForEach(x => QiitaItems.Add(x));
        }
    }
}
