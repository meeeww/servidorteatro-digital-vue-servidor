using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
namespace BankAPI.Data;
public class BankAPIContext : DbContext
{
    public BankAPIContext(DbContextOptions<BankAPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ID_Cliente);

        modelBuilder.Entity<Empleado>()
            .HasMany(e => e.RegistroVentas)
            .WithOne(rv => rv.Empleado)
            .HasForeignKey(em => em.ID_Empleado);

        modelBuilder.Entity<Producto>()
            .HasMany(p => p.DetallePedidos)
            .WithOne(dp => dp.Producto)
            .HasForeignKey(pr => pr.ID_Producto);

        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.DetallePedidos)
            .WithOne(dp => dp.Pedido)
            .HasForeignKey(pr => pr.ID_Pedido);

        modelBuilder.Entity<RegistroVentas>()
            .Property(r => r.ID_RegistroVentas)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<RegistroVentas>()
             .HasOne(rv => rv.Empleado)
             .WithMany(e => e.RegistroVentas)
             .HasForeignKey(rv => rv.ID_Empleado);

        modelBuilder.Entity<RegistroVentas>()
            .HasKey(rv => rv.ID_RegistroVentas);

        modelBuilder.Entity<DetallePedido>()
            .Property(p => p.ID_DetallePedido)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<DetallePedido>()
            .HasKey(pi => new { pi.ID_Pedido, pi.ID_Producto });

        modelBuilder.Entity<DetallePedido>()
            .HasOne(pi => pi.Pedido)
            .WithMany(p => p.DetallePedidos)
            .HasForeignKey(pi => pi.ID_Pedido);

        modelBuilder.Entity<DetallePedido>()
            .HasOne(pi => pi.Producto)
            .WithMany(i => i.DetallePedidos)
            .HasForeignKey(pi => pi.ID_Producto);

        modelBuilder.Entity<DetallePedido>()
            .Property(p => p.Subtotal)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Empleado>()
            .Property(p => p.Salario)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Pedido>()
            .Property(p => p.Total).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<RegistroVentas>()
            .Property(r => r.TotalCostos)
            .HasColumnType("decimal(11, 2)");
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RegistroVentas> RegistroVentas { get; set; }

}