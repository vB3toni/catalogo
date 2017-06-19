using FluentAssertions;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeusPedidos.Catalogo.Core.Test.Application
{
    [TestClass]
    public class CategoriaApplicationTest
    {
        private readonly Mock<ICategoriaApplication> _categoriaapplication;

        public CategoriaApplicationTest()
        {
            _categoriaapplication = new Mock<ICategoriaApplication>();
        }

        [TestMethod]
        public void Inserir_Novo_Categoria()
        {
            var categoria = ObterCategoria;

            var result = _categoriaapplication.Object.Inserir(categoria);

            result.IsValid.Should().Be(true, "Categoria inserido com sucesso");
        }

        [TestMethod]
        public void Atualizar_Novo_Categoria()
        {
            var categoria = ObterCategoria;

            var result = _categoriaapplication.Object.Update(categoria);

            result.IsValid.Should().Be(true, "Categoria atualizado com sucesso");
        }

        [TestMethod]
        public void Apagar_Novo_Categoria()
        {
            var categoria = ObterCategoria;

            var result = _categoriaapplication.Object.Delete(categoria);

            result.IsValid.Should().Be(true, "Categoria apagado com sucesso");
        }

        private Categoria ObterCategoria => new Categoria
        {
            Id = "Categoria 1",
            Descricao = "Categoria Categoria Categoria Categoria"
        };
    }
}
