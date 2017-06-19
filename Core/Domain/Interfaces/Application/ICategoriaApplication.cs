using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Application
{
    public interface ICategoriaApplication : IApplicationBase<Categoria>
    {
        Task<List<Categoria>> BuscarCategoriaServidor(string serveradress);
    }
}