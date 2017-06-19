using Android.App;
using Android.Content;
using Android.OS;

namespace MeusPedidos.Catalogo.Presentation.Droid.Service
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "android.content.SyncAdapter" })]
    [MetaData("android.content.SyncAdapter", Resource = "@xml/syncadapter")]
    public class AtualizacaoService : Android.App.Service
    {
        static AtualizacaoSyncAdapter _atualizacaoSyncAdapter;
        static readonly object SyncAdapterLock = new object();

        public override void OnCreate()
        {
            base.OnCreate();

            lock (SyncAdapterLock)
            {
                if (_atualizacaoSyncAdapter == null)
                    _atualizacaoSyncAdapter = new AtualizacaoSyncAdapter(ApplicationContext, true);
            }
        }

        public override IBinder OnBind(Intent intent)
        {
            return _atualizacaoSyncAdapter.SyncAdapterBinder;
        }
    }
}