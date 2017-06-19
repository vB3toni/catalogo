using System;
using Android.Accounts;
using Android.Content;
using Android.OS;
using Android.Runtime;
using MeusPedidos.Catalogo.Core.Application.ViewModels;
using MeusPedidos.Catalogo.Presentation.Droid.Components;

namespace MeusPedidos.Catalogo.Presentation.Droid.Service
{
    public class AtualizacaoSyncAdapter : AbstractThreadedSyncAdapter
    {
        private readonly ServicoAtualizacaoViewModel _servicoAtualizacao = new ServicoAtualizacaoViewModel();

        public AtualizacaoSyncAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public AtualizacaoSyncAdapter(Context context, bool autoInitialize) : base(context, autoInitialize)
        {
        }

        public AtualizacaoSyncAdapter(Context context, bool autoInitialize, bool allowParallelSyncs) : base(context, autoInitialize, allowParallelSyncs)
        {
        }

        public override void OnPerformSync(Account account, Bundle extras, string authority, ContentProviderClient provider, SyncResult syncResult)
        {
            if (_servicoAtualizacao.Notificacao == null)
            {
                _servicoAtualizacao.Notificacao += notificacao => NotificationBuilder.ShowNotification(Context, notificacao);
            }

            _servicoAtualizacao.IniciarDownloadDados();
        }
    }
}