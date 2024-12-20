using AmbienteApi.migrations.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmbienteApi.migrations.Context;

public partial class DbClimaticaContext : DbContext
{
    public DbClimaticaContext()
    {
    }

    public DbClimaticaContext(DbContextOptions<DbClimaticaContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public virtual DbSet<Registro> Registro { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Name=ConnectionStrings:DbClimaticaContext");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Registro_pkey");

            entity.ToTable("Registro");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('seq_registro'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasDefaultValueSql("now()")
                .HasColumnName("data");
            entity.Property(e => e.Luminosidade).HasColumnName("luminosidade");
            entity.Property(e => e.Pressao).HasColumnName("pressao");
            entity.Property(e => e.Temperatura).HasColumnName("temperatura");
            entity.Property(e => e.Umidade).HasColumnName("umidade");
            entity.Property(e => e.Interno).HasColumnName("interno");
        });
    }
}
