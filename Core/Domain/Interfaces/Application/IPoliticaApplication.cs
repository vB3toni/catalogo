using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Interfaces.Application
{
    public interface IPoliticaApplication : IApplicationBase<Politica>
    {
        Politica BuscarValorDescontoPoliticaPromocao(List<Politica> politicapromocao, List<CatalogoPromocao> promocoes, string idcategoriaitem);
    }
}