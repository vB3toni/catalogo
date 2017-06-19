
using System.Globalization;
using System.Reflection.Emit;

namespace MeusPedidos.Catalogo.Core.Application.Dtos
{
    public class ItensPedidoDto
    {
        public string IdProduto { get; set; }

        public string NomeProduto { get; set; }

        public int QtdeVenda { get; set; }

        public string QtdeVendaFormatada => QtdeVenda + " UN";

        public string PrecoVendaFormatado => PrecoVenda.ToString("C2", new CultureInfo("pt-br"));

        public double PrecoBruto { get; set; }

        public double PrecoVenda => PrecoBruto - PrecoBruto * (Desconto / 100);

        public string DescontoFormatado => Desconto.ToString("C2", new CultureInfo("pt-br")) + " %";

        public float Desconto { get; set; }

        public string FotoProduto { get; set; }
        
        public bool EntidadeValida { get; set; }

        public bool Favorito { get; set; }

        public string DrawableFavorito => Favorito ? "ic_favorito_ativo" : "ic_favorito_inativo";

        public ProdutoDto Produto { get; set; }

        public bool PossuiPromocaoAtiva => Desconto > 0;
    }
}