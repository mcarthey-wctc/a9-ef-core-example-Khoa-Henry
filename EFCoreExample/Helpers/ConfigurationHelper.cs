using Microsoft.Extensions.Configuration;

namespace EFCoreExample.Helpers;

public static class ConfigurationHelper
{
    // Method to get the configuration based on the environment name
    public static IConfiguration GetConfiguration(string environmentName)
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environmentName}.json", true, true)
            .Build();
    }
}
