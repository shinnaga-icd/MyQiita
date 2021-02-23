using System.ComponentModel;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;

namespace MyQiita.ViewModel
{
    public class ViewModelBase : BindableBase, INavigationAware, IInitialize, IDestructible, INotifyPropertyChanged
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>();

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
        public virtual void Initialize(INavigationParameters parameters) { }

        public virtual void Destroy() { }
    }
}
