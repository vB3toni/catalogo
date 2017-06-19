using System.Collections.Generic;
using System.Linq;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;

namespace MeusPedidos.Catalogo.Core.Data.Repositories
{
    public class ItensPedidoRepository : RepositoryBase<ItensPedido>, IItensPedidoRepository
    {
        public ItensPedidoRepository() : base(true)
        {
        }

        public bool InserirItensPedido(IEnumerable<CatalogoPromocao> promocaos)
        {
            var listaitens = new List<ItensPedido>();
            foreach (var catalogoPromocao in promocaos)
            {
                listaitens.AddRange(catalogoPromocao.ItensPedidos.Where(x => x.QtdeVenda > 0));
            }

            DeleteAll();

            return listaitens.Count <= 0 || InsertRange(listaitens);
        }
    }
}