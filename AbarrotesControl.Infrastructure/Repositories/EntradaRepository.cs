using Microsoft.EntityFrameworkCore;
using AbarrotesControl.Core.Entities;
using AbarrotesControl.Core.Interfaces;
using AbarrotesControl.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbarrotesControl.Infrastructure.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly AbarrotesContext _context;

        public EntradaRepository(AbarrotesContext context)
        {
            _context = context;
        }

        public async Task<EntradaMercaderia?> GetEntradaByIdAsync(int id)
        {
            return await _context.EntradasMercaderia
                .Include(e => e.DetalleEntradas)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RegistrarEntradaAsync(EntradaMercaderia entrada, Dictionary<int, int> stockAumentos)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.EntradasMercaderia.AddAsync(entrada);
                await _context.SaveChangesAsync();

                foreach (var item in stockAumentos)
                {
                    var producto = await _context.Productos.FindAsync(item.Key);
                    if (producto != null)
                    {
                        producto.StockActual += item.Value;
                        _context.Productos.Update(producto);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}