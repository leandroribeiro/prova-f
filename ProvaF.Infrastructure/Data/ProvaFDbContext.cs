using Microsoft.EntityFrameworkCore;
using ProvaF.Domain.Entities;

namespace ProvaF.Infrastructure.Data
{
    public class ProvaFDbContext : DbContext
    {
        public const string CONTAS_TABLE = "Contas";
        
        public DbSet<Conta> Contas { get; set; }
        
        public ProvaFDbContext(DbContextOptions<ProvaFDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaConfiguration());
        }
    }
}