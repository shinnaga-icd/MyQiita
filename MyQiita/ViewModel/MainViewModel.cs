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

namespace MyQiita.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string QiitaEndpoint = "https://qiita.com/api/v2/items?page=1&per_page=20";

        // Property
        public ReactiveCollection<QiitaItem> QiitaItems { get; set; } = new ReactiveCollection<QiitaItem>();
        public ReactiveProperty<QiitaItem> SelectedItem { get; set; } = new ReactiveProperty<QiitaItem>();
        public ICommand ItemSelectCommand { get; private set; }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "My Qiita";

            SetQiitaItems();

            SelectedItem.Where(x => x != null).Subscribe(x =>
            {
                _navigationService.NavigateAsync(Navigate.Item, (NavigateParams.ItemURL, x.url));
            });
        }

        //ListViewにQiitaアイテムをセット
        async private void SetQiitaItems()
        {
            RestService restService = new RestService();
            List<QiitaItem> items = await restService.GetQiitaItemsAsync(QiitaEndpoint);
            items.ForEach(x => QiitaItems.Add(x));
        }

    }
}
