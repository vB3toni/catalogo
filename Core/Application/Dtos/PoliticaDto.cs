
namespace MeusPedidos.Catalogo.Core.Application.Dtos
{
    public class PoliticaDto
    {
        public string IdPromocao { get; set; }

        public int QtdeMinima { get; set; }

        public double Desconto { get; set; }

        public bool EntidadeValida { get; set; }
    }
}