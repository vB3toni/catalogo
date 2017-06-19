using System;
using Android.App;
using Android.Content;
using MeusPedidos.Catalogo.Core.Application.Dtos;

namespace MeusPedidos.Catalogo.Presentation.Droid.Components
{
    public class NotificationBuilder
    {
        public static void ShowNotification(Context context, NotificacaoDto notificacao)
        {
            var builder = new Notification.Builder(context)
                .SetContentTitle(notificacao.Titulo)
                .SetContentText(notificacao.Descricao)
                .SetSmallIcon(Resource.Drawable.ic_empresa);

            NotificationDefaults? notificationalerts = null;

            if (notificacao.NotificarComSom)
            {
                notificationalerts = NotificationDefaults.Sound;
            }
            if (notificacao.NotificarComLuz)
            {
                notificationalerts = notificationalerts | NotificationDefaults.Lights;
            }
            if (notificacao.NotificarComVibracao)
            {
                notificationalerts = notificationalerts | NotificationDefaults.Vibrate;
            }

            if (notificationalerts != null)
            {
                builder.SetDefaults(notificationalerts.Value);
            }

            var notificationManager = NotificationManager.FromContext(context);
            notificationManager.Notify(Convert.ToInt32(DateTime.Now.ToString("hhmmssms")), builder.Build());
        }
    }
}