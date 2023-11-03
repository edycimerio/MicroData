using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Entities;
using Micro.Data.Domain.Interfaces.Repository;
using Micro.Data.Domain.Interfaces.Service;
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
    public class PedidoSpec
    {
        private PedidoService _pedidoService;
        private Mock<IPedidoRepository> _pedidoRepositoryMock;
        private Mock<IItensPedidoService> _itensPedidoServiceMock;
        private Mock<IProdutoRepository> _produtoRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _pedidoRepositoryMock = new Mock<IPedidoRepository>();
            _itensPedidoServiceMock = new Mock<IItensPedidoService>();
            _produtoRepositoryMock = new Mock<IProdutoRepository>();

            _pedidoService = new PedidoService(
                _pedidoRepositoryMock.Object,
                _itensPedidoServiceMock.Object,
                _produtoRepositoryMock.Object
            );
        }


        [Test]
        public async Task ConsultarPedido()
        {
            // Arrange
            int id = 1;
            var pedido = new Pedido { Id = id, Email = "test@test.com", DataPedido = DateTime.Now };
            var itemPedidoDto = new ItemPedidoDto { IdPedido = id, IdProduto = 1, Quantidade = 2 };
            var produto = new Produto { Id = 1, Valor = 10 };

            _pedidoRepositoryMock.Setup(x => x.Consultar(id)).ReturnsAsync(pedido);
            _itensPedidoServiceMock.Setup(x => x.ListItensPedidos(id)).ReturnsAsync(new List<ItemPedidoDto> { itemPedidoDto });
            _produtoRepositoryMock.Setup(x => x.Consultar(itemPedidoDto.IdProduto)).ReturnsAsync(produto);

            // Act
            var result = await _pedidoService.Consultar(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(pedido.Email, result.Email);
            Assert.AreEqual(pedido.DataPedido, result.DataPedido);
            
        }

        [Test]
        public async Task CreatePedido()
        {
            // Arrange
            var pedidoDto = new PedidoDto
            {
                Id = 1,
                Email = "test@test.com",
                DataPedido = DateTime.Now,
                Itens = new List<ItemPedidoDto> { new ItemPedidoDto { IdProduto = 1, Quantidade = 2 } },
                ValorTotal = 20
            };
            var pedido = new Pedido { Id = 1, Email = "test@test.com", DataPedido = pedidoDto.DataPedido, ValorTotal = pedidoDto.ValorTotal };
            var produto = new Produto { Id = 1, Valor = 10 };

            _pedidoRepositoryMock.Setup(x => x.Create(It.IsAny<Pedido>())).ReturnsAsync(pedido.Id);
            _produtoRepositoryMock.Setup(x => x.Consultar(pedidoDto.Itens[0].IdProduto)).ReturnsAsync(produto);

            // Act
            var result = await _pedidoService.Create(pedidoDto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditPedido()
        {
            // Arrange
            var pedidoDto = new PedidoDto
            {
                Id = 1,
                Email = "test@test.com",
                DataPedido = DateTime.Now,
                Itens = new List<ItemPedidoDto> { new ItemPedidoDto { IdProduto = 1, Quantidade = 2 } },
                ValorTotal = 20
            };
            var pedido = new Pedido { Id = 1, Email = "test@test.com", DataPedido = pedidoDto.DataPedido, ValorTotal = pedidoDto.ValorTotal };
            var produto = new Produto { Id = 1, Valor = 10 };

            _pedidoRepositoryMock.Setup(x => x.Edit(It.IsAny<Pedido>())).Returns(Task.CompletedTask);
            _itensPedidoServiceMock.Setup(x => x.DeletePorPedido(pedidoDto.Id)).ReturnsAsync(true);
            _produtoRepositoryMock.Setup(x => x.Consultar(pedidoDto.Itens[0].IdProduto)).ReturnsAsync(produto);

            // Act
            var result = await _pedidoService.Edit(pedidoDto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeletePedido()
        {
            // Arrange
            int id = 1;

            _pedidoRepositoryMock.Setup(x => x.Delete(id)).Returns(Task.CompletedTask);

            // Act
            var result = await _pedidoService.Delete(id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ListPedidos()
        {
            // Arrange
            var pedidos = new List<Pedido>
        {
            new Pedido { Id = 1, Email = "test1@test.com", DataPedido = DateTime.Now },
            new Pedido { Id = 2, Email = "test2@test.com", DataPedido = DateTime.Now }
        };

            _pedidoRepositoryMock.Setup(x => x.ListPedidos()).ReturnsAsync(pedidos);
            _itensPedidoServiceMock.Setup(x => x.ListItensPedidos(It.IsAny<int>()))
                .ReturnsAsync(new List<ItemPedidoDto> { new ItemPedidoDto { IdProduto = 1, Quantidade = 2 } });

            // Act
            var result = await _pedidoService.ListPedidos();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }



        [Test]
        public async Task ConsultarError()
        {
            // Arrange
            int id = -1;
            _pedidoRepositoryMock.Setup(x => x.Consultar(id)).ReturnsAsync((Pedido)null);

            // Act
            var result = await _pedidoService.Consultar(id);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task CreateError()
        {
            // Arrange
            PedidoDto dto = null;

            // Act
            var result = await _pedidoService.Create(dto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task EditError()
        {
            // Arrange
            PedidoDto dto = null;

            // Act
            var result = await _pedidoService.Edit(dto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task DeleteError()
        {
            // Arrange
            int id = -1;

            // Act
            var result = await _pedidoService.Delete(id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ListPedidosError()
        {
            // Arrange
            IList<Pedido> emptyList = new List<Pedido>();
            _pedidoRepositoryMock.Setup(x => x.ListPedidos()).ReturnsAsync(emptyList);

            // Act
            var result = await _pedidoService.ListPedidos();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
