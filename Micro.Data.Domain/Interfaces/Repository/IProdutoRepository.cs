using Micro.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto> Consultar(int? id);
        Task Create(Produto produtos);
        Task Edit(Produto produtos);
        Task Delete(int id);
        Task<IList<Produto>> ListProdutos();
        Task<ItemPedido> ConsultarPorItemPedido(int id);
    }
}
