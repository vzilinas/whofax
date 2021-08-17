using Microsoft.Extensions.Logging.Console;
using Whofax.Api;
using Whofax.Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
            .Build()
            .MigrateDatabase()
            .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(options =>
            {
                options.AddSimpleConsole(o =>
                {
                    o.SingleLine = true;
                    o.IncludeScopes = false;
                    o.TimestampFormat = "hh:mm:ss ";
                    o.ColorBehavior = LoggerColorBehavior.Enabled;
                });
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
