using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaF.Infrastructure.Data;

namespace ProvaF.Domain.Tests.IntegrationTests
{
    public abstract class BaseIntegrationTest
    {
        protected ProvaFDbContext Context;

        public BaseIntegrationTest()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkNpgsql()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ProvaFDbContext>();

            builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseInternalServiceProvider(serviceProvider);
            
            Context = new ProvaFDbContext(builder.Options);
        }
    }
}