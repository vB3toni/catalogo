using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Application
{
    public interface IProdutoApplication : IApplicationBase<Produto>
    {
        Task<List<Produto>> BuscaProdutosServidor(string serveradress);
    }
}