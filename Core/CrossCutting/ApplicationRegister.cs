using MeusPedidos.Catalogo.Core.Application.Services;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using SimpleInjector;

namespace MeusPedidos.Catalogo.Core.CrossCutting
{
    public static class ApplicationRegister
    {
        public static void Register(Container container)
        {
            container.Register<IProdutoApplication, ProdutoApplication>(Lifestyle.Transient);
            container.Register<ICategoriaApplication, CategoriaApplication>(Lifestyle.Transient);
            container.Register<IPromocaoApplication, PromocaoApplication>(Lifestyle.Transient);
            container.Register<IPoliticaApplication, PoliticaPromocaoApplication>(Lifestyle.Transient);
            container.Register<ICatalogoPromocaoApplication, CatalogoPromocaoApplication>(Lifestyle.Transient);
            container.Register<IItensPedidoApplication, ItensPedidoApplication>(Lifestyle.Transient);
        }
    }
}