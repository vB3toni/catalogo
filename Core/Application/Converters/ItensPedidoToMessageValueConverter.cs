using System;
using System.Globalization;
using System.Windows.Input;
using MeusPedidos.Catalogo.Core.Application.Message;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Plugins.Messenger;

namespace MeusPedidos.Catalogo.Core.Application.Converters
{
    public class ItensPedidoToMessageValueConverter : MvxValueConverter<string, ICommand>
    {
        protected override ICommand Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return new MvxCommand(() =>
            {
                var messenger = Mvx.Resolve<IMvxMessenger>();
                {
                    messenger.Publish(new ItensPedidoMessage(messenger, parameter, value));
                }
            });
        }
    }
}