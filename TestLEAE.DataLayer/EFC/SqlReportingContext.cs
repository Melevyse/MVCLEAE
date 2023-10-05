using Microsoft.EntityFrameworkCore;

namespace TestLEAE.DataLayer;

public class SqlReportingContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Founder> Founders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=dbLEAE;Trusted_Connection=True;");
    }

    public void Migrate()
    {
        Database.Migrate();
    }

    public SqlReportingContext(DbContextOptions<SqlReportingContext> options)
        : base(options)
    {

    }
}
