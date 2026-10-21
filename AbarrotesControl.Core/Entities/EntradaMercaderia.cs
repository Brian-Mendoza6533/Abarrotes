using System;
using System.Collections.Generic;

namespace AbarrotesControl.Core.Entities
{
    public class EntradaMercaderia
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public DateOnly FechaCompra { get; set; }
        public DateTime RegistradoEn { get; set; } = DateTime.Now;
        public string? Observacion { get; set; }

        public virtual Proveedor? Proveedor { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<DetalleEntrada> DetalleEntradas { get; set; } = new List<DetalleEntrada>();
    }
}