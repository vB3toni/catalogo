using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Repositories
{
    [TestClass]
    public class PromocaoRepositoryTest
    {
        private readonly Mock<IPromocaoRepository> _mockrepository;

        public PromocaoRepositoryTest()
        {
            _mockrepository = new Mock<IPromocaoRepository>();
        }


        [TestMethod]
        public void Inserir_Novo_Promocao()
        {
            var promocao = new Promocao { IdPromocao = "Promocao 1", Descricao= "1"};

            var result = _mockrepository.Object.Insert(promocao);

            result.Should().Be(true, "Promocao inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Promocao()
        {
            var promocao = new Promocao { IdPromocao = "Promocao 1", Descricao = "1" };

            var result = _mockrepository.Object.Update(promocao);

            result.Should().Be(true, "Promocao atualizado com sucesso");
        }

        [TestMethod]
        public void Delete_Promocao()
        {
            var promocao = new Promocao { IdPromocao = "Promocao 1", Descricao = "1" };

            var result = _mockrepository.Object.Delete(promocao);

            result.Should().Be(true, "Promocao apagado com sucesso");
        }

        [TestMethod]
        public void Buscar_Promocao_Servidor()
        {
            var retorno = _mockrepository.Object.FindListServer("https://pastebin.com/raw/R9cJFBtG");

            retorno.Result.Should().HaveCount(3, "possuem 3 Promocaos no arquivo json");
        }
    }
}