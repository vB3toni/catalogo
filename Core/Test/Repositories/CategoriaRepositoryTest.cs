using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Repositories
{
    [TestClass]
    public class CategoriaRepositoryTest
    {
        private readonly Mock<ICategoriaRepository> _mockrepository;

        public CategoriaRepositoryTest()
        {
            _mockrepository = new Mock<ICategoriaRepository>();
        }


        [TestMethod]
        public void Inserir_Novo_Categoria()
        {
            var categoria = new Categoria { Id = "Categoria 1", Descricao= "1"};

            var result = _mockrepository.Object.Insert(categoria);

            result.Should().Be(true, "Categoria inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Categoria()
        {
            var categoria = new Categoria { Id = "Categoria 1", Descricao = "1" };

            var result = _mockrepository.Object.Update(categoria);

            result.Should().Be(true, "Categoria atualizado com sucesso");
        }

        [TestMethod]
        public void Delete_Categoria()
        {
            var categoria = new Categoria { Id = "Categoria 1", Descricao = "1" };

            var result = _mockrepository.Object.Delete(categoria);

            result.Should().Be(true, "Categoria apagado com sucesso");
        }

        [TestMethod]
        public void Buscar_Categoria_Servidor()
        {
            var retorno = _mockrepository.Object.FindListServer("http://pastebin.com/raw/YNR2rsWe");

            retorno.Result.Should().HaveCount(5, "possuem 5 Categorias no arquivo json");
        }
    }
}