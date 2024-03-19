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

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Sesiones)
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.UserID);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Reservas)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.UserID);

        modelBuilder.Entity<Obra>()
            .HasMany(o => o.Funciones)
            .WithOne(f => f.Obra)
            .HasForeignKey(f => f.ObraID);

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

        modelBuilder.Entity<Obra>().HasData(
            new Obra { ObraID = 1, Titulo = "La vida es sueño", Director = "Pedro Calderón de la Barca", CategoriaID = 0 },
            new Obra { ObraID = 2, Titulo = "Hamlet", Director = "William Shakespeare", CategoriaID = 1 }
        );

        modelBuilder.Entity<Sala>().HasData(
            new Sala { SalaID = 1, Nombre = "Sala Principal", Capacidad = 100 },
            new Sala { SalaID = 2, Nombre = "Sala Secundaria", Capacidad = 50 }
        );

        modelBuilder.Entity<Funcion>().HasData(
            new Funcion { FuncionID = 1, FechaHora = new DateTime(2024, 3, 15, 20, 0, 0), ObraID = 1, SalaID = 1 },
            new Funcion { FuncionID = 2, FechaHora = new DateTime(2024, 3, 16, 20, 0, 0), ObraID = 2, SalaID = 2 },
            new Funcion { FuncionID = 3, FechaHora = new DateTime(2024, 3, 17, 18, 0, 0), ObraID = 1, SalaID = 1 }
        );

        modelBuilder.Entity<Reserva>().HasData(
            new Reserva { ReservaID = 1, FuncionID = 1, Asiento = 1, UserID = 1, FechaReserva = new DateTime(2024, 2, 20) },
            new Reserva { ReservaID = 2, FuncionID = 2, Asiento = 20, UserID = 2, FechaReserva = new DateTime(2024, 2, 21) },
            new Reserva { ReservaID = 3, FuncionID = 3, Asiento = 3, UserID = 1, FechaReserva = new DateTime(2024, 2, 22) }
        );
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sesion> Sesiones { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Funcion> Funciones { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

}