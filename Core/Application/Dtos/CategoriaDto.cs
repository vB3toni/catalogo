
namespace MeusPedidos.Catalogo.Core.Application.Dtos
{
    public class CategoriaDto 
    {
        public string Id { get; set; }

        public string Descricao { get; set; }

        public bool Selecionado { get; set; }

        public bool EntidadeValida { get; set; }
    }
}