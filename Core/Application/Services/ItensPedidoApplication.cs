using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Application.Services
{
    public class ItensPedidoApplication : ServiceBase<ItensPedido>, IItensPedidoApplication
    {
        private readonly IItensPedidoRepository _itensPedidoRepository;

        public ItensPedidoApplication(IItensPedidoRepository repositoryBase) : base(repositoryBase)
        {
            _itensPedidoRepository = repositoryBase;
        }

        public override ValidacaoResult ValidarEntidade(ItensPedido entity)
        {
            return entity.EntidadeValida ? new ValidacaoResult() : new ValidacaoResult(false, "Dados Incompletos");
        }

        public bool InserirItensPedido(IEnumerable<CatalogoPromocao> promocaos)
        {
            return _itensPedidoRepository.InserirItensPedido(promocaos);
        }

        public List<ItensPedido> BuscarTodosItens()
        {
            return _itensPedidoRepository.FindList();
        }
    }
}