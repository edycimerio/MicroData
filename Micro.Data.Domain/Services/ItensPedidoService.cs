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
    public class ItensPedidoService: IItensPedidoService
    {
        private readonly IItensPedidoRepository _repository;

        public ItensPedidoService(IItensPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(ItemPedidoDto dto)
        {
            ItemPedido item = new ItemPedido();

            if (dto != null)
            {
                item.Id = dto.Id;
                item.IdPedido = dto.IdPedido;
                item.IdProduto = dto.IdProduto;
                item.Quantidade = dto.Quantidade;
                item.ValorTotal = dto.ValorTotal;
                try
                {
                    await _repository.Create(item);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public async Task<IList<ItemPedidoDto>> ListItensPedidos(int idPedido)
        {
            var lista = await _repository.ListItensPedidos(idPedido);

            IList<ItemPedidoDto> listaRetorno = new List<ItemPedidoDto>();

            foreach (ItemPedido item in lista)
            {
                ItemPedidoDto dto = new ItemPedidoDto();
                dto.Id = item.Id;
                dto.IdPedido = item.IdPedido;
                dto.IdProduto = item.IdProduto;
                dto.Quantidade = item.Quantidade;
                dto.ValorTotal = item.ValorTotal;

                listaRetorno.Add(dto);
            }

            return listaRetorno;
        }

        public async Task<bool> Edit(ItemPedidoDto dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    ItemPedido item = new ItemPedido();

                    item.Id = dto.Id;
                    item.IdPedido = dto.IdPedido;
                    item.IdProduto = dto.IdProduto;
                    item.Quantidade = dto.Quantidade;
                    item.ValorTotal = dto.ValorTotal;

                    try
                    {
                        await _repository.Edit(item);

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

        public async Task<bool> DeletePorPedido(int idPedido)
        {
            try
            {
                if (idPedido > 0)
                {
                    await _repository.DeletePorPedido(idPedido);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
           
        }

        public async Task<IList<ItemPedidoDto>> ListItensPedidos()
        {
            var lista = await _repository.ListItensPedidos();

            IList<ItemPedidoDto> listaRetorno = new List<ItemPedidoDto>();

            foreach (ItemPedido item in lista)
            {
                ItemPedidoDto dto = new ItemPedidoDto();
                dto.Id = item.Id;
                dto.IdPedido = item.IdPedido;
                dto.IdProduto = item.IdProduto;
                dto.Quantidade = item.Quantidade;
                dto.ValorTotal = item.ValorTotal;

                listaRetorno.Add(dto);
            }

            return listaRetorno;
        }
    }
}
