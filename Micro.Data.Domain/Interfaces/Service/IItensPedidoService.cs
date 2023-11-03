using Micro.Data.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Interfaces.Service
{
    public interface IItensPedidoService
    {
        Task<IList<ItemPedidoDto>> ListItensPedidos(int idPedido);
        Task<bool> Create(ItemPedidoDto dto);
        Task<bool> Edit(ItemPedidoDto dto);
        Task<bool> Delete(int id);
        Task<IList<ItemPedidoDto>> ListItensPedidos();
        Task<bool> DeletePorPedido(int idPedido);
    }
}
