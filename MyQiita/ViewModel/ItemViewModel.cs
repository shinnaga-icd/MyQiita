using System;
using Xamarin.Forms;
using Prism.Navigation;
using Reactive.Bindings;

namespace MyQiita.ViewModel
{
    public class ItemViewModel : ViewModelBase
    {

        public ItemViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Qiita Page";
        }
    }
}
