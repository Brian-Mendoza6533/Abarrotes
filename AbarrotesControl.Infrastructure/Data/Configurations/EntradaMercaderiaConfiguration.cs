using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesControl.Core.Entities;

namespace AbarrotesControl.Infrastructure.Data.Configurations
{
    public class EntradaMercaderiaConfiguration : IEntityTypeConfiguration<EntradaMercaderia>
    {
        public void Configure(EntityTypeBuilder<EntradaMercaderia> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("entradas_mercaderia");

            entity.Property(e => e.Observacion).HasMaxLength(255);

            entity.HasOne(d => d.Proveedor)
                .WithMany()
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Usuario)
                .WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}