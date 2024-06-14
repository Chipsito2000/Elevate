using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

public partial class ElevateErpContext : DbContext
{
    public ElevateErpContext()
    {
    }

    public ElevateErpContext(DbContextOptions<ElevateErpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accion> Accions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Pantalla> Pantallas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MRACZESIN0;Database=ElevateERP;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accion>(entity =>
        {
            entity.HasOne(d => d.IdPantallaNavigation).WithMany(p => p.Accions).HasConstraintName("FK_Accion_Pantalla");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_Cliente");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_Proveedor");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasOne(d => d.IdAccionNavigation).WithMany(p => p.Permisos).HasConstraintName("FK_Permisos_Accion");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Permisos).HasConstraintName("FK_Permisos_Rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
