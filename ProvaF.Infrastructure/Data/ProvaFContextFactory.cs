using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProvaF.Infrastructure.Data
{
    public class ProvaFContextFactory : IDesignTimeDbContextFactory<ProvaFDbContext>
    {
        public ProvaFDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
         
         
              var builder = new DbContextOptionsBuilder<ProvaFDbContext>();
         
              var connectionString = configuration
                          .GetConnectionString("DefaultConnection");
         
              builder.UseNpgsql(connectionString);
              
            return new ProvaFDbContext(builder.Options);
        }
    }
}