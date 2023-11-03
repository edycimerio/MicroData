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
    public class ItensPedidoRepository : IItensPedidoRepository
    {
        private readonly ApplicationDbContext _context;
        public ItensPedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemPedido> Consultar(int id)
        {
            var itensPedidos = await _context.ItensPedidos
                .FirstOrDefaultAsync(m => m.Id == id);

            return itensPedidos;
        }
        public async Task<int> Create(ItemPedido itensPedidos)
        {
            _context.Add(itensPedidos);
            return await _context.SaveChangesAsync();
        }

        public async Task Edit(ItemPedido itensPedidos)
        {
            _context.Update(itensPedidos);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itensPedidos = await _context.ItensPedidos.FindAsync(id);
            _context.ItensPedidos.Remove(itensPedidos);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePorPedido(int idPedido)
        {
            var itensPedidos = await _context.ItensPedidos.Where(x => x.IdPedido == idPedido).ToListAsync();
            
            foreach (var item in itensPedidos)
                _context.ItensPedidos.Remove(item);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<ItemPedido>> ListItensPedidos()
        {
            var lista = await _context.ItensPedidos.ToListAsync();

            return lista;
        }

        public async Task<IList<ItemPedido>> ListItensPedidos(int idPedido)
        {
            var lista = await _context.ItensPedidos.Where(x => x.IdPedido == idPedido).ToListAsync();

            return lista;
        }
    }
}
