using System.Collections.Generic;

namespace MeusPedidos.Catalogo.Core.Application.Dtos
{
    public class CatalogoPromocaoDto
    {
        public string IdPromocao { get; set; }

        public string DescricaoPromocao { get; set; }

        public List<ItensPedidoDto> ItensPedidos { get; set; }

        public string IdCategoria { get; set; }
    }
}