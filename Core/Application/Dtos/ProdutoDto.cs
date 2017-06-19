
namespace MeusPedidos.Catalogo.Core.Application.Dtos
{
    public class ProdutoDto
    {
        public string IdProduto { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        public double Preco { get; set; }

        public string IdCategoria { get; set; }

        public bool Favorito { get; set; }

        public bool EntidadeValida { get; set; }
    }
}