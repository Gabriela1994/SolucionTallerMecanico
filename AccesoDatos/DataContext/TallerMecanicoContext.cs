using Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace AccesoDatos.DataContext
{
    public class TallerMecanicoContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapeamos la relacion muchos a muchos.
            modelBuilder.Entity<Revision>()
            .HasMany(r => r.Servicios)
            .WithMany(s => s.Revisiones)
            .UsingEntity<DetalleRevision>(
                r => r.HasOne<Servicio>().WithMany().HasForeignKey(p => p.IdServicio).OnDelete(DeleteBehavior.NoAction),
                l => l.HasOne<Revision>().WithMany().HasForeignKey(p => p.IdRevision).OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Vehiculo>()
                .HasMany(e => e.Revision)
                .WithOne(e => e.Vehiculo)
                .HasForeignKey(e => e.IdVehiculo)
                .HasPrincipalKey(e => e.IdVehiculo);
        }
    

        public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options) : base(options)
        {

        }

        public DbSet<Revision> Revision { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<DetalleRevision> DetalleRevision { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Marca> Marca { get; set; }
    }
}
