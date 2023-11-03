using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DataPedido { get; set; }
        public Decimal ValorTotal { get; set; }
        public IList<ItemPedidoDto> Itens { get; set; }

        
    }
}
