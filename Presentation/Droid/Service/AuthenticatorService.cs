using Android.App;
using Android.Content;
using Android.OS;

namespace MeusPedidos.Catalogo.Presentation.Droid.Service
{
    [Service]
    [IntentFilter(new[] { "android.accounts.AccountAuthenticator" })]
    [MetaData("android.accounts.AccountAuthenticator", Resource = "@xml/authenticator")]
    public class AuthenticatorService : Android.App.Service
    {
        Authenticator _authenticator;

        public override void OnCreate()
        {
            base.OnCreate();

            _authenticator = new Authenticator(this);
        }

        public override IBinder OnBind(Intent intent)
        {
            return _authenticator.IBinder;
        }
    }
}