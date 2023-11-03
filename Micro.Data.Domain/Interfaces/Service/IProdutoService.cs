using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Interfaces.Service
{
    public interface IProdutoService
    {
        Task<ProdutoDto> Consultar(int id);
        Task<bool> Create(ProdutoDto produtoDto);
        Task<bool> Edit(ProdutoDto produtoDto);
        Task<bool> Delete(int id);
        Task<IList<ProdutoDto>> ListProdutos();
        Task<ItemPedidoDto> ConsultarPorItemPedido(int id);
    }
}
