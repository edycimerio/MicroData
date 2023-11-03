using Micro.Data.Domain.Entities;
using Micro.Data.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Repository.Repositories
{   

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Consultar(int? id)
        {
            var _produtos = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);

            return _produtos;
        }
        public async Task Create(Produto produtos)
        {
            _context.Add(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Produto produtos)
        {
            _context.Update(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemPedido> ConsultarPorItemPedido(int id)
        {
            var itens = await _context.ItensPedidos
                .FirstOrDefaultAsync(m => m.IdProduto == id);

            return itens;
        }

        public async Task<IList<Produto>> ListProdutos()
        {
            var lista = await _context.Produtos.ToListAsync();

            return lista;
        }
    }
}
