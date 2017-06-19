using MeusPedidos.Catalogo.Core.Application.Dtos;
using MvvmCross.Plugins.Messenger;

namespace MeusPedidos.Catalogo.Core.Application.Message
{
    public class ItensPedidoMessage : MvxMessage
    {
        public ItensPedidoDto ItensPedidoDto { get; set; }

        public string Acao { get; set; }

        public ItensPedidoMessage(object sender, object item, string acao) : base(sender)
        {
            ItensPedidoDto = (ItensPedidoDto)item;

            Acao = acao;
        }
    }
}