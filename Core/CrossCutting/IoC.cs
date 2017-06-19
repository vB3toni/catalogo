using System;
using SimpleInjector;

namespace MeusPedidos.Catalogo.Core.CrossCutting
{
    public class IoC
    {
        public static readonly Container Container = new Container();

        public static void Register()
        {
            try
            {
                AutoMapper.Mapper.Initialize(x =>
                {
                    Application.Mappers.MapperConfiguration.ConfigAction.Invoke(x);
                });

                ApplicationRegister.Register(Container);

                RepositoryRegister.Register(Container);

                Container.Verify();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}