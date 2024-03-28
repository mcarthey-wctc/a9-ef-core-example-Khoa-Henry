using EFCoreExample.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCoreExample.Contexts.Factories;

public abstract class SchoolContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    public TContext CreateDbContext(string[] args)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = ConfigurationHelper.GetConfiguration(environmentName);

        var optionsBuilder = new DbContextOptionsBuilder<TContext>();
        ConfigureOptionsBuilder(optionsBuilder, configuration.GetConnectionString("DefaultConnection"));

        return CreateContext(optionsBuilder.Options);
    }

    // Abstract methods to be implemented by derived classes
    protected abstract void ConfigureOptionsBuilder(DbContextOptionsBuilder<TContext> optionsBuilder, string connectionString);
    protected abstract TContext CreateContext(DbContextOptions<TContext> options);
}
