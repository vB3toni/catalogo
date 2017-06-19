using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;
using SQLite.Net.Attributes;

namespace MeusPedidos.Catalogo.Core.Domain.Entidades
{
    [Table("Politica")]
    public class Politica : IEntidadeBase
    {
        public string IdPromocao { get; set; }

        public int QtdeMinima { get; set; }

        public double Desconto { get; set; }

        [Ignore]
        public bool EntidadeValida => !string.IsNullOrEmpty(IdPromocao) && QtdeMinima > 0;
    }
}