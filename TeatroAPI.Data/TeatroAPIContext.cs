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

        // Relación entre Sesiones y Usuarios
        modelBuilder.Entity<Sesion>()
            .HasOne<Usuario>()
            .WithMany()
            .HasForeignKey(s => s.UserID);

        // Relación entre Funciones, Obras y Salas
        modelBuilder.Entity<Funcion>()
            .HasOne<Obra>()
            .WithMany()
            .HasForeignKey(f => f.ObraID);

        modelBuilder.Entity<Funcion>()
            .HasOne<Sala>()
            .WithMany()
            .HasForeignKey(f => f.SalaID);

        // Relación entre Reservas, Funciones y Usuarios
        modelBuilder.Entity<Reserva>()
            .HasOne<Funcion>()
            .WithMany()
            .HasForeignKey(r => r.FuncionID);

        modelBuilder.Entity<Reserva>()
            .HasOne<Usuario>()
            .WithMany()
            .HasForeignKey(r => r.UserID);

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sesion> Sesiones { get; set; }
    public DbSet<Obra> Obras{ get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Funcion> Funciones { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

}