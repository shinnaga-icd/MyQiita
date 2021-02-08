using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyQiita.Models;
using MyQiita.Service;

namespace MyQiita
{
    public partial class MainPage : ContentPage
    {
        public const string QiitaEndpoint = "https://qiita.com/api/v2/items?page=1&per_page=20";
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();

        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //Item Views
            List<QiitaItem> items = await _restService.GetQiitaItemsAsync(QiitaEndpoint);
            ItemView.ItemsSource = items;

        }
    }
}
