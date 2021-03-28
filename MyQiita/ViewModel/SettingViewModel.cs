using System;
using Xamarin.Essentials;
using Prism.Commands;
using MyQiita.Common;
using IdentityModel.Client;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyQiita.ViewModel
{
    public class SettingViewModel
    {
        public DelegateCommand LoginCommand { get; set; }

        public SettingViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        private async void Login()
        {
            try
            {
                //Create AuthRequest
                var authRequest = new RequestUrl(Constants.QiitaOauthUrl);
                var param = new Parameters();
                param.Add("client_id", Constants.QiitaOauthClientID);
                param.Add("scope", "read_qiita");
                string requestUrl = authRequest.Create(param);

                //Auth
                var authResult = await WebAuthenticator.AuthenticateAsync(
                    new Uri(requestUrl),
                    new Uri(Constants.QiitaCallBackUrl));
                var accessToken = authResult?.AccessToken;
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
