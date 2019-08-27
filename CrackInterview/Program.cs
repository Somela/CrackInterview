using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CrackInterview
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static int Main(string[] args)
        {
            try
            {
                Configuration = new ConfigurationBuilder()
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", reloadOnChange: true, optional: false)
       .AddJsonFile($"AppIdUserIdTranslation.json", optional: true, reloadOnChange: true)
       .Build();
                Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(Configuration)
        .CreateLogger();
                Log.Information("Starting web host");
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseConfiguration(Configuration)
                    .UseSerilog()
                    .Build();

                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

    }
}
