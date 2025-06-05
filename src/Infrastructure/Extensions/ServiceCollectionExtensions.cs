using Infrastructure.Migrations;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<DatabaseOptions>(config.GetSection("Database"));

        var dbOptions = config.GetSection("Database").Get<DatabaseOptions>();

        services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(dbOptions!.ConnectionString));
        services.AddScoped<IUrlRepository, UrlRepository>();

        services.AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            .AddPostgres()
            .WithGlobalConnectionString(dbOptions!.ConnectionString)
            .ScanIn(typeof(Migration_0001_CreateUrlTable).Assembly).For.Migrations()
        )
        .AddLogging(lb => lb.AddFluentMigratorConsole());


        return services;
    }

    public static void ApplyMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var dbOptions = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
        Console.WriteLine("🔧 ApplyMigrations: usando banco " + dbOptions.ConnectionString);

        try
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            Console.WriteLine("🔧 MigrationRunner obtido com sucesso.");

            runner.MigrateUp();
            Console.WriteLine("✅ Migrations aplicadas com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Erro ao aplicar migrations: " + ex.Message);
            throw;
        }
    }

}
