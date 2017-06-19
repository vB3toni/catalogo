using System;
using Android.Accounts;
using Android.App;
using Android.OS;
using Android.Runtime;
using MeusPedidos.Catalogo.Core.CrossCutting;
using Android.Content;

namespace MeusPedidos.Catalogo.Presentation.Droid.Startup
{
    [Application]
    public sealed class GlobalApplication : Application
    {
        public const string AuthorityProviderName = "meuspedidos.catalogo.droid.service.provider";
        public const string TypeName = "meuspedidos.catalogo.droid";

        public Account AccountCatalogo { get; set; }

        public GlobalApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            
            IoC.Register();

            //#region Criar Conta Serviço

            //if (AccountCatalogo == null)
            //{
            //    AccountCatalogo = new Account("Serviço Atualização de Dados", TypeName);
            //    var accountManager = (AccountManager)Context.GetSystemService(AccountService);

            //    if (!accountManager.AddAccountExplicitly(AccountCatalogo, null, null))
            //    {
            //        Console.WriteLine("erro ao criar a conta");
            //    }
            //}

            //#endregion

            //#region Iniciar Download dados manual

            //var settingsBundle = new Bundle();

            //settingsBundle.PutBoolean(ContentResolver.SyncExtrasManual, true);
            //settingsBundle.PutBoolean(ContentResolver.SyncExtrasExpedited, true);

            //ContentResolver.RequestSync(AccountCatalogo, AuthorityProviderName, settingsBundle);

            //#endregion
        }
    }
}