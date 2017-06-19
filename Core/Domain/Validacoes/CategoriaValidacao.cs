using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Domain.Validacoes
{
    public class CategoriaValidacao
    {
        public ValidacaoResult ValidarCategoria(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Id))
            {
                return new ValidacaoResult(false, "favor informar id da categoria");
            }

            return string.IsNullOrEmpty(categoria.Descricao) ? new ValidacaoResult(false, "favor informar nome da categoria") : new ValidacaoResult();
        }
    }
}