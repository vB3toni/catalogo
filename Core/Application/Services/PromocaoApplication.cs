using System.Collections.Generic;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Application.Services
{
    public class PromocaoApplication : ServiceBase<Promocao>, IPromocaoApplication
    {
        private readonly IPromocaoRepository _promocaoRepository;
        private readonly PromocaoValidacao _promocaoValidacao;

        public PromocaoApplication(IPromocaoRepository repositoryBase) : base(repositoryBase)
        {
            _promocaoRepository = repositoryBase;

            _promocaoValidacao = new PromocaoValidacao();
        }

        public override ValidacaoResult ValidarEntidade(Promocao entity)
        {
            return _promocaoValidacao.ValidarPromocao(entity);
        }

        public Task<List<Promocao>> BuscarPromocaoServidor(string serveradress)
        {
            return _promocaoRepository.FindListServer(serveradress);
        }
    }
}