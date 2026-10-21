namespace AbarrotesControl.Core.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        public bool Activo { get; set; } = true;
    }
}