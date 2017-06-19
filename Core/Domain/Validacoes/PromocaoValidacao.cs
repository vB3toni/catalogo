using MeusPedidos.Catalogo.Core.Domain.Entidades;

namespace MeusPedidos.Catalogo.Core.Domain.Validacoes
{
    public class PromocaoValidacao
    {
        public ValidacaoResult ValidarPromocao(Promocao promocao)
        {
            if (string.IsNullOrEmpty(promocao.IdCategoria))
            {
                return new ValidacaoResult(false, "favor informar id categoria da promoção ");
            }

            if (string.IsNullOrEmpty(promocao.Descricao))
            {
                return new ValidacaoResult(false, "favor informar nome da promoção ");
            }

            return promocao.Politica == null ? new ValidacaoResult(false, "promoção sem politica") : new ValidacaoResult();
        }
    }
}