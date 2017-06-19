
using System.Collections.Generic;

namespace MeusPedidos.Catalogo.Core.Application.Dtos
{
    public class PromocaoDto
    {
        public string IdPromocao { get; set; }

        public string Descricao { get; set; }

        public string IdCategoria { get; set; }

        public List<PoliticaDto> Politica { get; set; }

        public bool EntidadeValida { get; set; }
    }
}