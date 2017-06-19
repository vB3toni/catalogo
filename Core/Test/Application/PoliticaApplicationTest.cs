using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Application
{
    [TestClass]
    public class PoliticaApplicationTest
    {
        private readonly Mock<IPoliticaApplication> _politicaapplication;

        public PoliticaApplicationTest()
        {
            _politicaapplication = new Mock<IPoliticaApplication>();
        }

        [TestMethod]
        public void Inserir_Novo_Politica()
        {
            var politica = ObterPolitica;

            var result = _politicaapplication.Object.Inserir(politica);

            result.IsValid.Should().Be(true, "Politica inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Novo_Politica()
        {
            var politica = ObterPolitica;

            var result = _politicaapplication.Object.Update(politica);

            result.IsValid.Should().Be(true, "Politica atualizado com sucesso");
        }

        [TestMethod]
        public void Apagar_Novo_Politica()
        {
            var politica = ObterPolitica;

            var result = _politicaapplication.Object.Delete(politica);

            result.IsValid.Should().Be(true, "Politica apagado com sucesso");
        }

        private Politica ObterPolitica => new Politica
        {
            IdPromocao = "Politica 1",
            QtdeMinima = 2,
            Desconto = 22
        };
    }
}
