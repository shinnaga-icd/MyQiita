using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Navigation;


namespace MyQiita.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, INavigationAware, IInitialize, IDestructible
    {
        protected INavigationService _navigationService;
        public event PropertyChangedEventHandler PropertyChanged;


        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                this.SetProperty<string>(ref this._title, value);
            }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
        public virtual void Initialize(INavigationParameters parameters) { }

        public virtual void Destroy() { }
    }
}
