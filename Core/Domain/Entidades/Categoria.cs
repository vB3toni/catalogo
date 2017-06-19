using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;
using SQLite.Net.Attributes;

namespace MeusPedidos.Catalogo.Core.Domain.Entidades
{
    [Table("Categoria")]
    public class Categoria : IEntidadeBase
    {
        [PrimaryKey]
        public string Id { get; set; }

        [NotNull]
        public string Descricao { get; set; }

        [Ignore]
        public bool Selecionado { get; set; }

        [Ignore]
        public bool EntidadeValida => !string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(Descricao);
    }
}