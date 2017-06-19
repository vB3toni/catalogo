using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Application.Services
{
    public class CategoriaApplication : ServiceBase<Categoria>, ICategoriaApplication
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly CategoriaValidacao _categoriaValidacao;

        public CategoriaApplication(ICategoriaRepository repositoryBase) : base(repositoryBase)
        {
            _categoriaRepository = repositoryBase;

            _categoriaValidacao = new CategoriaValidacao();
        }

        public override ValidacaoResult ValidarEntidade(Categoria entity)
        {
            return _categoriaValidacao.ValidarCategoria(entity);
        }

        public Task<List<Categoria>> BuscarCategoriaServidor(string serveradress)
        {
            return _categoriaRepository.FindListServer(serveradress);
        }
    }
}