using System;
using AutoMapper;
using MeusPedidos.Catalogo.Core.Application.Mappers.Profile;

namespace MeusPedidos.Catalogo.Core.Application.Mappers
{
    public static class MapperConfiguration
    {
        public static Action<IMapperConfigurationExpression> ConfigAction = x =>
        {
            x.AddProfile<CategoriaProfile>();
            x.AddProfile<PoliticaProfile>();
            x.AddProfile<ProdutoProfile>();
            x.AddProfile<PromocaoProfile>();
            x.AddProfile<CatalogoPromocaoProfile>();
            x.AddProfile<ItensPedidoProfile>();
        };
    }
}