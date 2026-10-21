using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesControl.Core.Entities;

namespace AbarrotesControl.Infrastructure.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("productos");

            entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Precio).HasPrecision(10, 2);
            entity.Property(e => e.Activo).HasColumnType("tinyint(1)").HasDefaultValue(true);

            entity.HasOne(d => d.Categoria)
                .WithMany()
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Creador)
                .WithMany()
                .HasForeignKey(d => d.CreadoPor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}