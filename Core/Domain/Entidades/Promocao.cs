using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;
using SQLite.Net.Attributes;

namespace MeusPedidos.Catalogo.Core.Domain.Entidades
{
    [Table("Promocao")]
    public class Promocao : IEntidadeBase
    {
        [PrimaryKey]
        public string IdPromocao { get; set; }

        [NotNull]
        public string Descricao { get; set; }

        [NotNull]
        public string IdCategoria { get; set; }

        [Ignore]
        public List<Politica> Politica { get; set; }

        [Ignore]
        public bool EntidadeValida => !string.IsNullOrEmpty(IdPromocao) &&
                                      !string.IsNullOrEmpty(Descricao) &&
                                      !string.IsNullOrEmpty(IdCategoria);
    }
}