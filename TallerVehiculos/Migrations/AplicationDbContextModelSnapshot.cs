﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TallerVehiculos.Data;

#nullable disable

namespace TallerVehiculos.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TallerVehiculos.Models.Ciudades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("ciudades");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("TallerVehiculos.Models.DetalleFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductosId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProductosId");

                    b.ToTable("detalleFacturas");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClientesId")
                        .HasColumnType("int");

                    b.Property<int?>("Usuariosid")
                        .HasColumnType("int");

                    b.Property<string>("fecha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientesId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Usuariosid");

                    b.ToTable("facturas");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("ProveedorId");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("proveedores");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Sedes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CiudadesId")
                        .HasColumnType("int");

                    b.Property<int>("IdCiudades")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CiudadesId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("sedes");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("servicio");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Usuarios", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("IdSedes")
                        .HasColumnType("int");

                    b.Property<int?>("SedesId")
                        .HasColumnType("int");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("SedesId");

                    b.HasIndex("id")
                        .IsUnique();

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClientesId")
                        .HasColumnType("int");

                    b.Property<int?>("ServicioId")
                        .HasColumnType("int");

                    b.Property<string>("modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientesId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("placa")
                        .IsUnique();

                    b.ToTable("vehiculo");
                });

            modelBuilder.Entity("TallerVehiculos.Models.DetalleFactura", b =>
                {
                    b.HasOne("TallerVehiculos.Models.Factura", null)
                        .WithMany("detalleFacturas")
                        .HasForeignKey("FacturaId");

                    b.HasOne("TallerVehiculos.Models.Productos", null)
                        .WithMany("detalleFacturas")
                        .HasForeignKey("ProductosId");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Factura", b =>
                {
                    b.HasOne("TallerVehiculos.Models.Clientes", null)
                        .WithMany("facturas")
                        .HasForeignKey("ClientesId");

                    b.HasOne("TallerVehiculos.Models.Usuarios", null)
                        .WithMany("facturas")
                        .HasForeignKey("Usuariosid");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Productos", b =>
                {
                    b.HasOne("TallerVehiculos.Models.Proveedor", null)
                        .WithMany("productos")
                        .HasForeignKey("ProveedorId");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Sedes", b =>
                {
                    b.HasOne("TallerVehiculos.Models.Ciudades", null)
                        .WithMany("sedes")
                        .HasForeignKey("CiudadesId");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Usuarios", b =>
                {
                    b.HasOne("TallerVehiculos.Models.Sedes", null)
                        .WithMany("usuario")
                        .HasForeignKey("SedesId");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Vehiculo", b =>
                {
                    b.HasOne("TallerVehiculos.Models.Clientes", null)
                        .WithMany("vehiculos")
                        .HasForeignKey("ClientesId");

                    b.HasOne("TallerVehiculos.Models.Servicio", null)
                        .WithMany("vehiculos")
                        .HasForeignKey("ServicioId");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Ciudades", b =>
                {
                    b.Navigation("sedes");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Clientes", b =>
                {
                    b.Navigation("facturas");

                    b.Navigation("vehiculos");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Factura", b =>
                {
                    b.Navigation("detalleFacturas");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Productos", b =>
                {
                    b.Navigation("detalleFacturas");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Proveedor", b =>
                {
                    b.Navigation("productos");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Sedes", b =>
                {
                    b.Navigation("usuario");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Servicio", b =>
                {
                    b.Navigation("vehiculos");
                });

            modelBuilder.Entity("TallerVehiculos.Models.Usuarios", b =>
                {
                    b.Navigation("facturas");
                });
#pragma warning restore 612, 618
        }
    }
}
