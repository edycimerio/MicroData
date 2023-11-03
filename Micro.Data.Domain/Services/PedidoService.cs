using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Entities;
using Micro.Data.Domain.Interfaces.Repository;
using Micro.Data.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IItensPedidoService _itensPedidoService;
        private readonly IProdutoRepository _produtoRepository;



        public PedidoService(IPedidoRepository repository, IItensPedidoService itensPedidoService,
            IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _itensPedidoService = itensPedidoService;
            _produtoRepository = produtoRepository;

        }

        public async Task<PedidoDto> Consultar(int id)
        {
            var _pedidos = await _repository.Consultar(id);
            PedidoDto dto = new PedidoDto();

            if (_pedidos != null)
            {
                dto.Id = _pedidos.Id;
                dto.Email = _pedidos.Email;
                dto.DataPedido = _pedidos.DataPedido;
                dto.Itens = await _itensPedidoService.ListItensPedidos(_pedidos.Id);
                dto.ValorTotal = dto.Itens.Sum(x => x.ValorTotal);
            }

            return dto;
        }
        public async Task<bool> Create(PedidoDto dto)
        {
            Pedido pedido = new Pedido();

            if (dto != null)
            {
                pedido.Id = dto.Id;
                pedido.Email = dto.Email;
                pedido.DataPedido = dto.DataPedido;
                pedido.ValorTotal = dto.ValorTotal;
                try
                {
                    var idPedido = await _repository.Create(pedido);

                    foreach (ItemPedidoDto _item in dto.Itens)
                    {
                        var produto = await _produtoRepository.Consultar(_item.IdProduto);
                        _item.IdPedido = idPedido;
                        _item.ValorTotal = produto.Valor * _item.Quantidade;
                        await _itensPedidoService.Create(_item);
                    }                   

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> Edit(PedidoDto dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    Pedido pedido = new Pedido();

                    pedido.Id = dto.Id;
                    pedido.Email = dto.Email;
                    pedido.DataPedido = dto.DataPedido;
                    pedido.ValorTotal = dto.ValorTotal;

                    try
                    {
                        await _repository.Edit(pedido);

                        await _itensPedidoService.DeletePorPedido(pedido.Id);

                        foreach (ItemPedidoDto _item in dto.Itens)
                        {
                            var produto = await _produtoRepository.Consultar(_item.IdProduto);
                            _item.IdPedido = pedido.Id;
                            _item.ValorTotal = produto.Valor * _item.Quantidade;
                            await _itensPedidoService.Create(_item);
                        }

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    await _repository.Delete(id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public async Task<IList<PedidoDto>> ListPedidos()
        {
            var lista = await _repository.ListPedidos();

            IList<PedidoDto> listaRetorno = new List<PedidoDto>();

            foreach (Pedido pedido in lista)
            {
                PedidoDto dto = new PedidoDto();
                dto.Id = pedido.Id;
                dto.Email = pedido.Email;
                dto.DataPedido = pedido.DataPedido;               
                dto.Itens = await _itensPedidoService.ListItensPedidos(pedido.Id);
                dto.ValorTotal = dto.Itens.Sum(x => x.ValorTotal);

                listaRetorno.Add(dto);
            }

            return listaRetorno;
        }
    }
}
