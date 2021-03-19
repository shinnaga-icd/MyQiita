﻿using System;
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

        /// <summary>
        /// ListViewにQiitaItemをセット
        /// </summary>
        async private void SetQiitaItems()
        {
            ScrapingService scrapingService = new ScrapingService();
            QiitaScrapingItem item = await scrapingService.GetQiitaTrends();

            item.QiitaItems.ToList().ForEach(x => QiitaItems.Add(x));
        }

    }
}
