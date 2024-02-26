using DDDWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DDDWebAPI.Infrastructure.Data;

public class SqlContext : DbContext
{
    public SqlContext()
    {
    }
    
    public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => 
                     entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Property("DataCadastro").IsModified = false;
                    break;
            }
        }

        return base.SaveChanges();
    }
}
