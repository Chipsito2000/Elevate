﻿// <auto-generated />
using ElevateERP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElevateERP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240721195351_AddFilePropertiesToDocumento")]
    partial class AddFilePropertiesToDocumento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElevateERP.Models.Accion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accion1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Accion");

                    b.Property<int?>("IdPantalla")
                        .HasColumnType("int")
                        .HasColumnName("idPantalla");

                    b.HasKey("Id");

                    b.HasIndex("IdPantalla");

                    b.ToTable("Accion");
                });

            modelBuilder.Entity("ElevateERP.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cfdi")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CFDI");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FormaPago")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("formaPago");

                    b.Property<string>("NEmpresa")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("nEmpresa");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ElevateERP.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrato")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Cotizacion")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Factura")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdProveedor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("ElevateERP.Models.Pantalla", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NPantalla")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nPantalla");

                    b.HasKey("Id");

                    b.ToTable("Pantalla");
                });

            modelBuilder.Entity("ElevateERP.Models.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdAccion")
                        .HasColumnType("int")
                        .HasColumnName("idAccion");

                    b.Property<int>("IdRol")
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    b.HasKey("Id");

                    b.HasIndex("IdAccion");

                    b.HasIndex("IdRol");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("ElevateERP.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FormaCompra")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("formaCompra");

                    b.Property<string>("NEmpresa")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("nEmpresa");

                    b.Property<string>("Nombre")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("ElevateERP.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Rol1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Rol");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("ElevateERP.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Usuario1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ElevateERP.Models.Accion", b =>
                {
                    b.HasOne("ElevateERP.Models.Pantalla", "IdPantallaNavigation")
                        .WithMany("Accions")
                        .HasForeignKey("IdPantalla")
                        .HasConstraintName("FK_Accion_Pantalla");

                    b.Navigation("IdPantallaNavigation");
                });

            modelBuilder.Entity("ElevateERP.Models.Documento", b =>
                {
                    b.HasOne("ElevateERP.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Documentos")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_Documento_Cliente");

                    b.HasOne("ElevateERP.Models.Proveedor", "IdProveedorNavigation")
                        .WithMany("Documentos")
                        .HasForeignKey("IdProveedor")
                        .HasConstraintName("FK_Documento_Proveedor");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdProveedorNavigation");
                });

            modelBuilder.Entity("ElevateERP.Models.Permiso", b =>
                {
                    b.HasOne("ElevateERP.Models.Accion", "IdAccionNavigation")
                        .WithMany("Permisos")
                        .HasForeignKey("IdAccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Permisos_Accion");

                    b.HasOne("ElevateERP.Models.Rol", "IdRolNavigation")
                        .WithMany("Permisos")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Permisos_Rol");

                    b.Navigation("IdAccionNavigation");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("ElevateERP.Models.Usuario", b =>
                {
                    b.HasOne("ElevateERP.Models.Rol", "IdRolNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_Rol");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("ElevateERP.Models.Accion", b =>
                {
                    b.Navigation("Permisos");
                });

            modelBuilder.Entity("ElevateERP.Models.Cliente", b =>
                {
                    b.Navigation("Documentos");
                });

            modelBuilder.Entity("ElevateERP.Models.Pantalla", b =>
                {
                    b.Navigation("Accions");
                });

            modelBuilder.Entity("ElevateERP.Models.Proveedor", b =>
                {
                    b.Navigation("Documentos");
                });

            modelBuilder.Entity("ElevateERP.Models.Rol", b =>
                {
                    b.Navigation("Permisos");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
