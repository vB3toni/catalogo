using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Application
{
    [TestClass]
    public class ProdutoApplicationTest
    {
        private readonly Mock<IProdutoApplication> _produtoapplication;

        public ProdutoApplicationTest()
        {
            _produtoapplication = new Mock<IProdutoApplication>();
        }

        [TestMethod]
        public void Inserir_Novo_Produto()
        {
            var produto = ObterProduto;

            var result = _produtoapplication.Object.Inserir(produto);

            result.IsValid.Should().Be(true, "produto inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Novo_Produto()
        {
            var produto = ObterProduto;

            var result = _produtoapplication.Object.Update(produto);

            result.IsValid.Should().Be(true, "produto atualizado com sucesso");
        }

        [TestMethod]
        public void Apagar_Novo_Produto()
        {
            var produto = ObterProduto;

            var result = _produtoapplication.Object.Delete(produto);

            result.IsValid.Should().Be(true, "produto apagado com sucesso");
        }

        private Produto ObterProduto => new Produto
        {
            Nome = "Produto 1",
            IdCategoria = "1",
            Descricao = "produto produto produto produto",
            Preco = 100,
            Foto =
                "https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/06cfe8d6-48f8-11e6-9634-02184f9c0531.jpeg"
        };
    }
}
