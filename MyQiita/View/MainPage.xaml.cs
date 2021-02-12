using System;
using Xamarin.Forms;
using MyQiita.Model;

namespace MyQiita.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnListViewItemSelected(Object sender, SelectedItemChangedEventArgs args)
        {
            QiitaItem item = args.SelectedItem as QiitaItem;
            if(item != null)
            {
                await Navigation.PushAsync(new ItemPage(item));
            }
        }
    }
}
