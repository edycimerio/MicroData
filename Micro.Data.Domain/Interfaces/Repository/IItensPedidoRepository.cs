using Micro.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Interfaces.Repository
{
    public interface IItensPedidoRepository
    {
        Task<ItemPedido> Consultar(int id);
        Task<int> Create(ItemPedido itensPedidos);
        Task Edit(ItemPedido itensPedidos);
        Task Delete(int id);
        Task<IList<ItemPedido>> ListItensPedidos();
        Task<IList<ItemPedido>> ListItensPedidos(int idPedido);
        Task DeletePorPedido(int idPedido);
    }
}
