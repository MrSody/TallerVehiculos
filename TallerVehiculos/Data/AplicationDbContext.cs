using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TallerVehiculos.Data.Entities;
using TallerVehiculos.Models;

namespace TallerVehiculos.Data
{
    public class AplicationDbContext : IdentityDbContext<User>
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Ciudades> ciudades { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Clientes> clientes { get; set; }

        public DbSet<DetalleFactura> detalleFacturas { get; set; }

        public DbSet<Factura> facturas { get; set; }

        public DbSet<Productos> productos { get; set; }

        public DbSet<Proveedor> proveedores { get; set; }

        public DbSet<Sedes> sedes { get; set; }

        public DbSet<Servicio> servicio { get; set; }

        public DbSet<Usuarios> usuarios { get; set; }

        public DbSet<Vehiculo> vehiculo { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Ciudades>(ciu =>
            //{
            //    ciu.HasIndex("Nombre").IsUnique();
            //    ciu.HasMany(c => c.sedes).WithOne(d => d.Ciudades).OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<Sedes>(sed =>
            //{
            //    sed.HasIndex("id", "CiudadesId").IsUnique();
            //    sed.HasOne(d => d.Ciudades).WithMany(c => c.sedes).OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<Usuarios>(usu =>
            //{
            //    usu.HasIndex("id", "SedesId").IsUnique();
            //    usu.HasOne(c => c.Sedes).WithMany(d => d.usuarios).OnDelete(DeleteBehavior.Cascade);
            //});

            modelBuilder.Entity<Ciudades>()
            .HasIndex(t => t.Nombre)
            .IsUnique();

            modelBuilder.Entity<Sedes>()
            .HasIndex(t => t.Id)
            .IsUnique();

            modelBuilder.Entity<Usuarios>()
            .HasIndex(t => t.id)
            .IsUnique();

            modelBuilder.Entity<Clientes>()
           .HasIndex(t => t.Id)
           .IsUnique();


            modelBuilder.Entity<Factura>()
         .HasIndex(t => t.Id)
         .IsUnique();

            modelBuilder.Entity<Productos>()
         .HasIndex(t => t.Nombre)
         .IsUnique();

            modelBuilder.Entity<Proveedor>()
         .HasIndex(t => t.Id)
         .IsUnique();

            modelBuilder.Entity<Servicio>()
         .HasIndex(t => t.Nombre)
         .IsUnique();

            modelBuilder.Entity<Vehiculo>()
         .HasIndex(t => t.placa)
         .IsUnique();

            modelBuilder.Entity<DetalleFactura>()
        .HasIndex(t => t.Id)
        .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(t => t.Name)
                .IsUnique();


        }
    }



}


