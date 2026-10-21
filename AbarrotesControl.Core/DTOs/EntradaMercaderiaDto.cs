using System.Collections.Generic;

namespace AbarrotesControl.Core.DTOs
{
    public class EntradaMercaderiaDto
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public string FechaCompra { get; set; } = null!;
        public string? Observacion { get; set; }
        public List<DetalleEntradaDto> Detalle { get; set; } = new List<DetalleEntradaDto>();
    }
}