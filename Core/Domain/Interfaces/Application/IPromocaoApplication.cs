using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Application
{
    public interface IPromocaoApplication : IApplicationBase<Promocao>
    {
        Task<List<Promocao>> BuscarPromocaoServidor(string serveradress);
    }
}