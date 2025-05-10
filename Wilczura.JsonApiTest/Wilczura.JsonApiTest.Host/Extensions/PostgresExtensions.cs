using Microsoft.EntityFrameworkCore;
using Npgsql;
using Wilczura.JsonApiTest.Adapters.Postgres;

namespace Wilczura.JsonApiTest.Host.Extensions;

public static class PostgresExtensions
{
    public static IHostApplicationBuilder AddPostgres(
        this IHostApplicationBuilder app, string sectionName, string connectionName, ILogger logger)
    {
        IConfiguration section = string.IsNullOrWhiteSpace(sectionName)
        ? app.Configuration
        : app.Configuration.GetSection(sectionName);
        var connectionString = section.GetConnectionString(connectionName);
        if (string.IsNullOrEmpty(connectionString))
        {
            logger?.LogError($"Connection string '${connectionName}' is empty");
        }
        else
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            var dataSource = dataSourceBuilder.Build();

            app.Services.AddDbContextPool<TestDbContext>(opt =>
                opt.UseNpgsql(dataSource, x => x.MigrationsHistoryTable("__ef_migrations_history"))
                    .UseSnakeCaseNamingConvention());
        }

        return app;
    }
}
