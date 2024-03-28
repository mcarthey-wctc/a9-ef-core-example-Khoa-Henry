using EFCoreExample.Contexts.Factories;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Contexts;

public class SchoolContextSqlServer : SchoolContext
{
    public SchoolContextSqlServer(DbContextOptions<SchoolContextSqlServer> options) : base(options)
    {
    }

    public class SchoolContextSqlServerFactory : SchoolContextFactory<SchoolContextSqlServer>
    {
        // Method to configure the options builder with the SQL Server connection string
        protected override void ConfigureOptionsBuilder(DbContextOptionsBuilder<SchoolContextSqlServer> optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override SchoolContextSqlServer CreateContext(DbContextOptions<SchoolContextSqlServer> options)
        {
            return new SchoolContextSqlServer(options);
        }
    }
}
