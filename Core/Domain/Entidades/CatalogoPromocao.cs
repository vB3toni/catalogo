using System.Collections.Generic;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Base;

namespace MeusPedidos.Catalogo.Core.Domain.Entidades
{
    public class CatalogoPromocao : IEntidadeBase
    {
        public string IdPromocao { get; set; }

        public string DescricaoPromocao { get; set; }

        public List<ItensPedido> ItensPedidos { get; set; }

        public bool EntidadeValida => !string.IsNullOrEmpty(IdPromocao) && ItensPedidos.Count > 0;

        public string IdCategoria { get; set; }
    }
}