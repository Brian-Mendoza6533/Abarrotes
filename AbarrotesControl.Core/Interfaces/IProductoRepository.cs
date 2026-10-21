using AbarrotesControl.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbarrotesControl.Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductosAsync();
        Task<Producto?> GetProductoByIdAsync(int id);
        Task InsertProductoAsync(Producto producto);
    }
}