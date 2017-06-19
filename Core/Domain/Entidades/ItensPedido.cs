using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;
using SQLite.Net.Attributes;

namespace MeusPedidos.Catalogo.Core.Domain.Entidades
{
    [Table("ItensPedido")]
    public class ItensPedido : IEntidadeBase
    {
        public string IdProduto { get; set; }

        public string NomeProduto { get; set; }

        public int QtdeVenda { get; set; }

        public double PrecoBruto { get; set; }

        [Ignore]
        public double PrecoVenda => PrecoBruto - PrecoBruto * (Desconto / 100);

        public double Desconto { get; set; }

        public string FotoProduto { get; set; }

        [Ignore]
        public bool EntidadeValida => !string.IsNullOrEmpty(NomeProduto) && QtdeVenda > 0 && PrecoBruto > 0;

        [Ignore]
        public bool Favorito { get; set; }

        [Ignore]
        public Produto Produto { get; set; }
    }
}