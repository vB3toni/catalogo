using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Application
{
    [TestClass]
    public class PromocaoApplicationTest
    {
        private readonly Mock<IPromocaoApplication> _promocaoapplication;

        public PromocaoApplicationTest()
        {
            _promocaoapplication = new Mock<IPromocaoApplication>();
        }

        [TestMethod]
        public void Inserir_Novo_Promocao()
        {
            var promocao = ObterPromocao;

            var result = _promocaoapplication.Object.Inserir(promocao);

            result.IsValid.Should().Be(true, "Promocao inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Novo_Promocao()
        {
            var promocao = ObterPromocao;

            var result = _promocaoapplication.Object.Update(promocao);

            result.IsValid.Should().Be(true, "Promocao atualizado com sucesso");
        }

        [TestMethod]
        public void Apagar_Novo_Promocao()
        {
            var promocao = ObterPromocao;

            var result = _promocaoapplication.Object.Delete(promocao);

            result.IsValid.Should().Be(true, "Promocao apagado com sucesso");
        }

        private Promocao ObterPromocao => new Promocao
        {
            IdPromocao = "Promocao 1",
            Descricao = "Promocao Promocao Promocao Promocao",
            IdCategoria = "1"
        };
    }
}
