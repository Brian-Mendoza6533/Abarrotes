using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesControl.Core.Entities;

namespace AbarrotesControl.Infrastructure.Data.Configurations
{
    public class DetalleEntradaConfiguration : IEntityTypeConfiguration<DetalleEntrada>
    {
        public void Configure(EntityTypeBuilder<DetalleEntrada> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("detalle_entrada");

            entity.Property(e => e.CostoUnitario).HasPrecision(10, 2);

            entity.HasOne(d => d.EntradaMercaderia)
                .WithMany(p => p.DetalleEntradas)
                .HasForeignKey(d => d.EntradaId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Producto)
                .WithMany(p => p.DetalleEntradas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}