using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Xamarin.Forms;
using MyQiita.View;
using MyQiita.Model;
using MyQiita.Service;
using Reactive.Bindings;

namespace MyQiita.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string QiitaEndpoint = "https://qiita.com/api/v2/items?page=1&per_page=20";

        // Property
        private List<QiitaItem> qiitaItems;
        public List<QiitaItem> QiitaItems
        {
            get { return qiitaItems; }
            set { SetProperty<List<QiitaItem>>(ref qiitaItems, value); }
        }

        // Command
        public ReactiveCommand ItemSelectCommand { get; } = new ReactiveCommand();

        // Constructor
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            SetQiitaItems();
            ItemSelectCommand.Subscribe(_ =>  NavigationService.NavigateAsync("NavigationPage/ItemPage"));
        }

        //ListViewにQiitaアイテムをセット
        async private void SetQiitaItems()
        {
            RestService restService = new RestService();
            List<QiitaItem> items = await restService.GetQiitaItemsAsync(QiitaEndpoint);
            QiitaItems = items;
        }

    }
}
