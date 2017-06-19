using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;
using SQLite.Net.Attributes;

namespace MeusPedidos.Catalogo.Core.Domain.Entidades
{
    [Table("Produto")]
    public class Produto : IEntidadeBase
    {
        [PrimaryKey]
        public string IdProduto { get; set; }

        [NotNull]
        public string Nome { get; set; }

        [NotNull]
        public string Descricao { get; set; }

        [NotNull]
        public string Foto { get; set; }

        public double Preco { get; set; }

        [NotNull]
        public string IdCategoria { get; set; }

        public bool Favorito { get; set; }

        [Ignore]
        public bool EntidadeValida => !string.IsNullOrEmpty(Nome) &&
                                      !string.IsNullOrEmpty(Descricao) &&
                                      !string.IsNullOrEmpty(Foto) &&
                                      Preco> 0 &&
                                      !string.IsNullOrEmpty(IdCategoria);
    }
}