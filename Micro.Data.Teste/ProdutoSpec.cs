using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Entities;
using Micro.Data.Domain.Interfaces.Repository;
using Micro.Data.Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Teste
{
    public class ProdutoSpec
    {
        private ProdutoService _produtoService;
        private Mock<IProdutoRepository> _produtoRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object);
        }

        [Test]
        public async Task ConsultarProduto()
        {
            // Arrange
            int id = 1;
            var produto = new Produto { Id = id, CodidoProduto = "ABC123", Valor = 10 };

            _produtoRepositoryMock.Setup(x => x.Consultar(id)).ReturnsAsync(produto);

            // Act
            var result = await _produtoService.Consultar(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(produto.CodidoProduto, result.CodidoProduto);
            Assert.AreEqual(produto.Valor, result.Valor);
        }

        [Test]
        public async Task CreateProduto()
        {
            // Arrange
            var produtoDto = new ProdutoDto { Id = 1, CodidoProduto = "ABC123", Valor = 10 };
            var produto = new Produto { Id = produtoDto.Id, CodidoProduto = produtoDto.CodidoProduto, Valor = produtoDto.Valor };

            _produtoRepositoryMock.Setup(x => x.Create(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            var result = await _produtoService.Create(produtoDto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditProduto()
        {
            // Arrange
            var produtoDto = new ProdutoDto { Id = 1, CodidoProduto = "ABC123", Valor = 10 };
            var produto = new Produto { Id = produtoDto.Id, CodidoProduto = produtoDto.CodidoProduto, Valor = produtoDto.Valor };

            _produtoRepositoryMock.Setup(x => x.Edit(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act
            var result = await _produtoService.Edit(produtoDto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteProduto()
        {
            // Arrange
            int id = 1;

            _produtoRepositoryMock.Setup(x => x.Delete(id)).Returns(Task.CompletedTask);

            // Act
            var result = await _produtoService.Delete(id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ListProdutos()
        {
            // Arrange
            var produtos = new List<Produto>
        {
            new Produto { Id = 1, CodidoProduto = "ABC123", Valor = 10 },
            new Produto { Id = 2, CodidoProduto = "DEF456", Valor = 20 }
        };

            _produtoRepositoryMock.Setup(x => x.ListProdutos()).ReturnsAsync(produtos);

            // Act
            var result = await _produtoService.ListProdutos();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task ConsultarPorItemPedido()
        {
            // Arrange
            int id = 1;
            var itemPedido = new ItemPedido { Id = id, IdPedido = 1, IdProduto = 1, Quantidade = 2, ValorTotal = 20 };

            _produtoRepositoryMock.Setup(x => x.ConsultarPorItemPedido(id)).ReturnsAsync(itemPedido);

            // Act
            var result = await _produtoService.ConsultarPorItemPedido(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(itemPedido.IdPedido, result.IdPedido);
            Assert.AreEqual(itemPedido.IdProduto, result.IdProduto);
            Assert.AreEqual(itemPedido.Quantidade, result.Quantidade);
            Assert.AreEqual(itemPedido.ValorTotal, result.ValorTotal);
        }





        [Test]
        public async Task ConsultarInvalidId()
        {
            // Arrange
            int id = -1;
            _produtoRepositoryMock.Setup(x => x.Consultar(id)).ReturnsAsync((Produto)null);

            // Act
            var result = await _produtoService.Consultar(id);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task CreateProdutoError()
        {
            // Arrange
            ProdutoDto produtoDto = null;

            // Act
            var result = await _produtoService.Create(produtoDto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task EditProdutoError()
        {
            // Arrange
            ProdutoDto produtoDto = null;

            // Act
            var result = await _produtoService.Edit(produtoDto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task DeleteProdutoError()
        {
            // Arrange
            int id = -1;

            // Act
            var result = await _produtoService.Delete(id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ListProdutosProdutoError()
        {
            // Arrange
            IList<Produto> emptyList = new List<Produto>();
            _produtoRepositoryMock.Setup(x => x.ListProdutos()).ReturnsAsync(emptyList);

            // Act
            var result = await _produtoService.ListProdutos();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public async Task ConsultarPorItemPedidoError()
        {
            // Arrange
            int id = -1;
            _produtoRepositoryMock.Setup(x => x.ConsultarPorItemPedido(id)).ReturnsAsync((ItemPedido)null);

            // Act
            var result = await _produtoService.ConsultarPorItemPedido(id);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
