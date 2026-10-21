namespace AbarrotesControl.Core.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int CategoriaId { get; set; }
        public decimal Precio { get; set; }
        public int StockMinimo { get; set; }
        public string? FechaVencimiento { get; set; }
        public int CreadoPor { get; set; }
    }
}