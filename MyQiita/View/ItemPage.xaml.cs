using System;
using Xamarin.Forms;
using MyQiita.Model;

namespace MyQiita.View
{
    public partial class ItemPage : ContentPage
    {
        public ItemPage(QiitaItem item)
        {
            InitializeComponent();
            BindingContext = item;
        }
    }
}
