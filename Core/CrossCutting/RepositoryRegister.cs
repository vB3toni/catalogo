using MeusPedidos.Catalogo.Core.Data.Repositories;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using SimpleInjector;

namespace MeusPedidos.Catalogo.Core.CrossCutting
{
    public static class RepositoryRegister
    {
        public static void Register(Container container)
        {
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Singleton);
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Singleton);
            container.Register<IPromocaoRepository, PromocaoRepository>(Lifestyle.Singleton);
            container.Register<IPoliticaRepository, PoliticaRepository>(Lifestyle.Singleton);
            container.Register<ICatalogoPromocaoRepository, CatalogoPromocaoRepository>(Lifestyle.Singleton);
            container.Register<IItensPedidoRepository, ItensPedidoRepository>(Lifestyle.Singleton);
        }
    }
}