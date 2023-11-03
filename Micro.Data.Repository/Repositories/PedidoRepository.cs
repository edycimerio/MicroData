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
    
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;
        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> Consultar(int id)
        {
            var _pedidos = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Id == id);

            return _pedidos;
        }
        public async Task<int> Create(Pedido pedidos)
        {
            _context.Add(pedidos);
            await _context.SaveChangesAsync();
            _context.Entry(pedidos).GetDatabaseValues();

            return pedidos.Id;
        }

        public async Task Edit(Pedido pedidos)
        {
            _context.Update(pedidos);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var _pedidos = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(_pedidos);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Pedido>> ListPedidos()
        {
            var lista = await _context.Pedidos.ToListAsync();

            return lista;
        }
    }
}
