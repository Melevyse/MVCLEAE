using Microsoft.EntityFrameworkCore;

namespace TestLEAE.DataLayer;

public class SqlReportingContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Founder> Founders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    public async void Migrate()
    {
        await Database.MigrateAsync();
    }

    public SqlReportingContext(DbContextOptions<SqlReportingContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .ToTable("Clients");

        modelBuilder.Entity<Founder>()
            .ToTable("Founders");

        modelBuilder.Entity<Client>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Founder>()
            .HasKey(f => f.Id);

        modelBuilder.Entity<Founder>()
            .HasOne(f => f.Client)
            .WithMany(c => c.Founders)
            .HasForeignKey(f => f.IdClient);

        modelBuilder.Entity<Client>()
            .HasIndex(c => new { c.Name, c.Inn })
            .IsUnique();
    }
}
