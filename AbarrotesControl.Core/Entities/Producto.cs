using System;
using System.Collections.Generic;

namespace AbarrotesControl.Core.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int CategoriaId { get; set; }
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public DateOnly? FechaVencimiento { get; set; }
        public bool Activo { get; set; } = true;
        public int CreadoPor { get; set; }
        public DateTime CreadoEn { get; set; } = DateTime.Now;

        public virtual Categoria? Categoria { get; set; }
        public virtual Usuario? Creador { get; set; }
        public virtual ICollection<DetalleEntrada> DetalleEntradas { get; set; } = new List<DetalleEntrada>();
    }
}