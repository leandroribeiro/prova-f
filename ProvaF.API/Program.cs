using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProvaF.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(
                        (host, builder) =>
                        {
                            builder.SetBasePath(Directory.GetCurrentDirectory());
                            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                            builder.AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json",
                                optional: true);
                            builder.AddEnvironmentVariables();
                            builder.AddCommandLine(args);
                        });
                    webBuilder.UseStartup<Startup>();
                });

    }
}