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
    }

    public DbSet<Usuario> Usuarios { get; set; }

}