using System.Collections.Generic;
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

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // contas básicas para testes
            var seed = new List<Conta> {new Conta(1), new Conta(2), new Conta(3)};

            // atribuindo saldo
            seed.ForEach(c => c.Depositar(c.Id * 100));

            modelBuilder.Entity<Conta>()
                .HasData(seed);
        }
    }
}