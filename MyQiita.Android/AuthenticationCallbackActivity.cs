using Android.App;
using Android.Content;
using Android.OS;

using Xamarin.Essentials;

namespace MyQiita.Droid
{
    [Activity(Label = "AuthenticationCallbackActivity")]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
        Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
        DataScheme = "myqiita",
        DataHost = "oauth")]
    public class AuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {
    }
}
