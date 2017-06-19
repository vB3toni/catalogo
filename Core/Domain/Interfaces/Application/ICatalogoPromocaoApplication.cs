using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Application
{
    public interface ICatalogoPromocaoApplication : IApplicationBase<CatalogoPromocao>
    {
        List<CatalogoPromocao> BuscarTodosCatalogoPromocao(string idcategoria);

        double SomarTotalVendido(IEnumerable<ItensPedido> listacatalogopromocao);

        double SomarTotalVendido(IEnumerable<CatalogoPromocao> listacatalogopromocao);

        int SomarTotalItensVendidos(IEnumerable<ItensPedido> listacatalogopromocao);

        int SomarTotalItensVendidos(IEnumerable<CatalogoPromocao> listacatalogopromocao);
    }
}