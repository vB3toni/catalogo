using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Application
{
    [TestClass]
    public class ItensPedidoApplicationTest
    {
        private readonly Mock<IItensPedidoApplication> _itensPedidoapplication;

        public ItensPedidoApplicationTest()
        {
            _itensPedidoapplication = new Mock<IItensPedidoApplication>();
        }

        [TestMethod]
        public void Inserir_Novo_ItensPedido()
        {
            var itensPedido = ObterItensPedido;

            var result = _itensPedidoapplication.Object.Inserir(itensPedido);

            result.IsValid.Should().Be(true, "ItensPedido inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Novo_ItensPedido()
        {
            var itensPedido = ObterItensPedido;

            var result = _itensPedidoapplication.Object.Update(itensPedido);

            result.IsValid.Should().Be(true, "ItensPedido atualizado com sucesso");
        }

        [TestMethod]
        public void Apagar_Novo_ItensPedido()
        {
            var itensPedido = ObterItensPedido;

            var result = _itensPedidoapplication.Object.Delete(itensPedido);

            result.IsValid.Should().Be(true, "ItensPedido apagado com sucesso");
        }

        private ItensPedido ObterItensPedido => new ItensPedido
        {
            IdProduto = "1",
            NomeProduto = "celular ",
            QtdeVenda = 1,
            PrecoBruto = 230.36,
            Desconto = 2,
            FotoProduto = "https://simplest-meuspedidos-arquivos.s3.amazonaws.com/media/imagem_produto/133421/fe41bc44-48f7-11e6-a3ac-0a9a90ee83e3.jpeg",
            Favorito = false,
        };
    }
}
