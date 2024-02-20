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
    }

    public DbSet<Usuario> Usuario { get; set; }

}