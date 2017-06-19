using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;

namespace MeusPedidos.Catalogo.Core.Data.Repositories
{
    public class PoliticaRepository : RepositoryBase<Politica>, IPoliticaRepository
    {
        public PoliticaRepository() : base(true)
        {
        }
    }
}