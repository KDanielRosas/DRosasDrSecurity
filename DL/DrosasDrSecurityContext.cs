using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class DrosasDrSecurityContext : DbContext
{
    public DrosasDrSecurityContext()
    {
    }

    public DrosasDrSecurityContext(DbContextOptions<DrosasDrSecurityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colonium> Colonia { get; set; }

    public virtual DbSet<DatosPersonale> DatosPersonales { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= DRosasDrSecurity; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colonium>(entity =>
        {
            entity.HasKey(e => e.IdColonia).HasName("PK__Colonia__A1580F6690A7C55C");

            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Colonia)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Colonia__IdMunic__2C3393D0");
        });

        modelBuilder.Entity<DatosPersonale>(entity =>
        {
            entity.HasKey(e => e.IdDatosPersonales).HasName("PK__DatosPer__C29AB0C8AC3ADE75");

            entity.Property(e => e.Celular)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.DatosPersonales)
                .HasForeignKey(d => d.IdDireccion)
                .HasConstraintName("FK__DatosPers__IdDir__34C8D9D1");

            entity.HasOne(d => d.IdEstadoNacimientoNavigation).WithMany(p => p.DatosPersonales)
                .HasForeignKey(d => d.IdEstadoNacimiento)
                .HasConstraintName("FK__DatosPers__IdEst__33D4B598");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C762B9D3F2C");

            entity.ToTable("Direccion");

            entity.Property(e => e.Calle)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("FK__Direccion__IdCol__30F848ED");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Direccion__IdEst__2F10007B");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Direccion__IdMun__300424B4");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC1539BB965");

            entity.ToTable("Estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978F386F8C6");

            entity.ToTable("Municipio");

            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Municipio__IdEst__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
