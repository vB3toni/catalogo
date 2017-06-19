using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<List<Produto>> FindListServer(string serveradress);
    }
}