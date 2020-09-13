using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProvaF.Infrastructure.Data
{
    public class ProvaFContextFactory : IDesignTimeDbContextFactory<ProvaFDbContext>
    {
        public ProvaFDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProvaFDbContext>();
            // TODO mover para ler da própria API
            builder.UseNpgsql("Server=127.0.0.1;Port=54321;Database=provaf;User Id=provaf_user;Password=S3nh4F0rt3!;");

            return new ProvaFDbContext(builder.Options);
        }
    }
}