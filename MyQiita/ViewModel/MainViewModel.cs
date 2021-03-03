﻿using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Reactive.Linq;
using Prism.Events;
using Prism.Commands;
using Prism.Navigation;
using MyQiita.Model;
using MyQiita.Service;
using MyQiita.Navigation;
using Reactive.Bindings;

namespace MyQiita.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string QiitaEndpoint = "https://qiita.com/api/v2/items?page=1&per_page=20";

        // Property
        private List<QiitaItem> _qiitaItems;
        public List<QiitaItem> QiitaItems
        {
            get => _qiitaItems;
            set => SetProperty<List<QiitaItem>>(ref this._qiitaItems, value);
        }
    
        // Constructor
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "My Qiita";

            SetQiitaItems();
            ItemSelectCommand = new DelegateCommand(OnItemSelectCommand);
        }

        // Command
        public ICommand ItemSelectCommand { get; }
        private void OnItemSelectCommand()
        {
            _navigationService.NavigateAsync(Navigate.Item, (NavigateParams.ItemURL, "https://google.com"));
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
