using System;
using Xamarin.Forms;
using Prism.Navigation;
using Reactive.Bindings;
using MyQiita.Navigation;

namespace MyQiita.ViewModel
{
    public class ItemViewModel : ViewModelBase
    {
        //Property
        public ReactiveProperty<string> Url { get; set; } = new ReactiveProperty<string>();

        public ItemViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Qiita Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(NavigateParams.ItemURL))
            {
                Url.Value = parameters.GetValue<string>(NavigateParams.ItemURL);
            }
        }
    }
}
