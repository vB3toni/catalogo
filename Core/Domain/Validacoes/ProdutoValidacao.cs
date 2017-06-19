using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Domain.Validacoes
{
    public class ProdutoValidacao
    {
        public ValidacaoResult ValidarProduto(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                return new ValidacaoResult(false, "Favor informar nome do produto");
            }

            if (string.IsNullOrEmpty(produto.IdCategoria))
            {
                return new ValidacaoResult(false, "Favor informar categoria do produto");
            }

            return string.IsNullOrEmpty(produto.Foto) ? new ValidacaoResult(false, "Favor informar foto do produto") : new ValidacaoResult();
        }
    }
}