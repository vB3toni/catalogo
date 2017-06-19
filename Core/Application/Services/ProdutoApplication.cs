using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using MeusPedidos.Catalogo.Core.Domain.Validacoes;

namespace MeusPedidos.Catalogo.Core.Application.Services
{
    public class ProdutoApplication : ServiceBase<Produto>, IProdutoApplication
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ProdutoValidacao _produtoValidacao;


        public ProdutoApplication(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;

            _produtoValidacao = new ProdutoValidacao();
        }
        
        public override ValidacaoResult ValidarEntidade(Produto entity)
        {
            return _produtoValidacao.ValidarProduto(entity);
        }

        public Task<List<Produto>> BuscaProdutosServidor(string serveradress)
        {
            return _produtoRepository.FindListServer(serveradress);
        }        
    }
}