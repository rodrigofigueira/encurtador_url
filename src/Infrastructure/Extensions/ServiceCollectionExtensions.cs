namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        var dbOptions = new DatabaseOptions();
        config.GetSection("Database").Bind(dbOptions);

        services.Configure<DatabaseOptions>(config.GetSection("Database"));

        if (dbOptions.Provider == "sqlite")
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSQLite()
                    .WithGlobalConnectionString(dbOptions.ConnectionString)
                    .ScanIn(typeof(Migration_0001_CreateUrlTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            services.AddScoped<IDbConnection>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;
                return new SqliteConnection(options.ConnectionString);
            });

            services.AddScoped<IUrlRepository, UrlRepositoryDapper>();
        }

        //futuro configurar a conexão para o postgres

        return services;
    }

    public static void ApplyMigrations(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var dbOptions = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

        if (dbOptions.Provider == "sqlite")
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
        else
        {
            // futuro: aplicar migrations do EF Core aqui
        }
    }

}
