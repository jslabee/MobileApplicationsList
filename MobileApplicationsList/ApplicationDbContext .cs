using Microsoft.EntityFrameworkCore;
using MobileApplicationsList.repository.DbModel;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AplicationDetails> aplicationdetails { get; set; }
    public DbSet<ApplicationBase> application { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
