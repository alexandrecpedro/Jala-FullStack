using ExchangeAPI.Modules.Wallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExchangeAPI.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Currency> Currencies { get; set; }
}