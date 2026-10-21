using Microsoft.EntityFrameworkCore;
using AbarrotesControl.Core.Entities;
using AbarrotesControl.Core.Interfaces;
using AbarrotesControl.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbarrotesControl.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AbarrotesContext _context;

        public ProductoRepository(AbarrotesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task InsertProductoAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }
    }
}