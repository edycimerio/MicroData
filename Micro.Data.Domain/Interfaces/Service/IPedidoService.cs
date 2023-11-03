using Micro.Data.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Interfaces.Service
{
    public interface IPedidoService
    {
        Task<PedidoDto> Consultar(int id);
        Task<bool> Create(PedidoDto dto);
        Task<bool> Edit(PedidoDto dto);
        Task<bool> Delete(int id);
        Task<IList<PedidoDto>> ListPedidos();
    }
}
