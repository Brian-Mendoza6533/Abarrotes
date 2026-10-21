using Microsoft.EntityFrameworkCore;
using AbarrotesControl.Core.Entities;
using System.Reflection;

namespace AbarrotesControl.Infrastructure.Data
{
    public class AbarrotesContext : DbContext
    {
        public AbarrotesContext(DbContextOptions<AbarrotesContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<EntradaMercaderia> EntradasMercaderia { get; set; }
        public DbSet<DetalleEntrada> DetalleEntradas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}