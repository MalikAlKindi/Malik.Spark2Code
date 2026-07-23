using Microsoft.EntityFrameworkCore;

namespace EFCoreEssentialsTask;

public class AppDbContext : DbContext
{
    public DbSet<BankAccount> BankAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Environment.GetEnvironmentVariable("BANK_DB_CONNECTION")
            ?? "Server=.;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connectionString);
    }
}
