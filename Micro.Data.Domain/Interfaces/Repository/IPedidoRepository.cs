using Micro.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedido> Consultar(int id);
        Task<int> Create(Pedido pedidos);
        Task Edit(Pedido pedidos);
        Task Delete(int id);
        Task<IList<Pedido>> ListPedidos();
    }
}
