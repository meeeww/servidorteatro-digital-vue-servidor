using Microsoft.EntityFrameworkCore;
using TeatroAPI.Model;
namespace TeatroAPI.Data;
public class TeatroAPIContext : DbContext
{
    public TeatroAPIContext(DbContextOptions<TeatroAPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.UserID)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Sesion>()
           .Property(s => s.SessionID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Obra>()
           .Property(o => o.ObraID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Sala>()
           .Property(s => s.SalaID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Funcion>()
           .Property(f => f.FuncionID)
           .ValueGeneratedOnAdd();

        modelBuilder.Entity<Reserva>()
           .Property(r => r.ReservaID)
           .ValueGeneratedOnAdd();

        // Configuración de Usuario
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Sesiones)
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.UserID);
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Reservas)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.UserID);

        // Configuración de Obra
        modelBuilder.Entity<Obra>()
            .HasMany(o => o.Funciones)
            .WithOne(f => f.Obra)
            .HasForeignKey(f => f.ObraID);

        // Configuración de Sala
        modelBuilder.Entity<Sala>()
            .HasMany(s => s.Funciones)
            .WithOne(f => f.Sala)
            .HasForeignKey(f => f.SalaID);

        modelBuilder.Entity<Funcion>()
    .HasOne(f => f.Obra)
    .WithMany(o => o.Funciones)
    .HasForeignKey(f => f.ObraID);

        modelBuilder.Entity<Funcion>()
            .HasOne(f => f.Sala)
            .WithMany(s => s.Funciones)
            .HasForeignKey(f => f.SalaID);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Funcion)
            .WithMany(f => f.Reservas)
            .HasForeignKey(r => r.FuncionID);


    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sesion> Sesiones { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Funcion> Funciones { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

}