using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Repositories
{
    [TestClass]
    public class ProdutoRepositoryTest
    {
        private readonly Mock<IProdutoRepository> _mockrepository;

        public ProdutoRepositoryTest()
        {
            _mockrepository = new Mock<IProdutoRepository>();
        }


        [TestMethod]
        public void Inserir_Novo_Produto()
        {
            var produto = new Produto {Nome = "Produto 1", IdCategoria = "1", Descricao = "produto produto produto produto", Preco = 100, Foto = "https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/06cfe8d6-48f8-11e6-9634-02184f9c0531.jpeg" };

            var result = _mockrepository.Object.Insert(produto);

            result.Should().Be(true, "produto inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Produto()
        {
            var produto = new Produto { Nome = "Produto 100", IdCategoria = "1", Descricao = "produto produto produto produto", Preco = 100, Foto = "https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/06cfe8d6-48f8-11e6-9634-02184f9c0531.jpeg" };

            var result = _mockrepository.Object.Update(produto);

            result.Should().Be(true, "produto atualizado com sucesso");
        }

        [TestMethod]
        public void Delete_Produto()
        {
            var produto = new Produto { Nome = "Produto 100", IdCategoria = "1", Descricao = "produto produto produto produto", Preco = 100, Foto = "https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/06cfe8d6-48f8-11e6-9634-02184f9c0531.jpeg" };

            var result = _mockrepository.Object.Delete(produto);

            result.Should().Be(true, "produto apagado com sucesso");
        }

        [TestMethod]
        public void Buscar_Produto_Servidor()
        {
            var retorno = _mockrepository.Object.FindListServer("http://pastebin.com/raw/W7tdL7NU");

            retorno.Result.Should().HaveCount(15, "possuem 15 produtos no arquivo json");
        }
    }
}
