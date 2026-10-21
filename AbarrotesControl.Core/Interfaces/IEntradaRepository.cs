using AbarrotesControl.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbarrotesControl.Core.Interfaces
{
    public interface IEntradaRepository
    {
        Task<EntradaMercaderia?> GetEntradaByIdAsync(int id);
        Task RegistrarEntradaAsync(EntradaMercaderia entrada, Dictionary<int, int> stockAumentos);
    }
}