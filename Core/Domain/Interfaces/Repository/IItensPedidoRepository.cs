using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository
{
    public interface IItensPedidoRepository : IRepositoryBase<ItensPedido>
    {
        bool InserirItensPedido(IEnumerable<CatalogoPromocao> promocaos);
    }
}