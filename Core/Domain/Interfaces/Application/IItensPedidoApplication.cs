using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Application
{
    public interface IItensPedidoApplication : IApplicationBase<ItensPedido>
    {
        bool InserirItensPedido(IEnumerable<CatalogoPromocao> promocaos);
        List<ItensPedido> BuscarTodosItens();
    }
}