using Inventario.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Data
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options) { }

        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Existencia> Existencias { get; set; }
        public DbSet<MovimientoInv> Movimientos_Inv { get; set; }
        public DbSet<ReservaStock> ReservaStock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo explícito para evitar el error "Invalid object name"
            modelBuilder.Entity<Bodega>().ToTable("Bodega");
            modelBuilder.Entity<Existencia>().ToTable("Existencias");
            modelBuilder.Entity<MovimientoInv>().ToTable("Movimientos_Inv");
            modelBuilder.Entity<ReservaStock>().ToTable("ReservaStock");
        }
    }
}
