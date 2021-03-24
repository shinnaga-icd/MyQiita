using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Prism.Commands;
using MyQiita.Common;

namespace MyQiita.ViewModel
{
    public class SettingViewModel
    {
        public DelegateCommand LoginCommand { get; set; }

        public SettingViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            Launcher.OpenAsync($"{Constants.QiitaOauthUrl}?client_id={Constants.QiitaOauthClientID}&scope=read_qiita");
        }
    }
}
