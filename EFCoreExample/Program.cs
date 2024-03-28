using EFCoreExample.Contexts;
using EFCoreExample.Helpers;
using EFCoreExample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreExample;

internal class Program
{
    private static void ApplyMigrations(IServiceScope scope)
    {
        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();

        if (env.IsEnvironment("Testing"))
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SchoolContextSqlite>();
            dbContext.Database.Migrate();
        }
        else
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SchoolContextSqlServer>();
            dbContext.Database.Migrate();
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var configuration = ConfigurationHelper.GetConfiguration(hostingContext.HostingEnvironment.EnvironmentName);
                config.AddConfiguration(configuration);
            })
            .ConfigureServices((hostContext, services) => { new Startup(hostContext.Configuration).ConfigureServices(services); });
    }

    private static void LogEnvironment(IServiceScope scope)
    {
        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
        Console.WriteLine($"Current environment: {env.EnvironmentName}");
    }

    private static async Task Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();

        ApplyMigrations(scope);
        LogEnvironment(scope);

        var mainService = scope.ServiceProvider.GetRequiredService<MainService>();
        await mainService.RunAsync();
    }
}
