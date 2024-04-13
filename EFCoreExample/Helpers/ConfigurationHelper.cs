using System;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
