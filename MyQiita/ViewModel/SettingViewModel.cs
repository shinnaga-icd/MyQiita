using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using MyQiita.Common;

namespace MyQiita.ViewModel
{
    public class SettingViewModel
    {
        public ICommand LoginCommand { get; set; }

        public SettingViewModel()
        {
            
        }

        private void Login()
        {
            Launcher.OpenAsync($"{Constants.QiitaOauthUrl}?client_id={Constants.QiitaOauthClientID}&scope=read_qiita");
        }
    }
}
