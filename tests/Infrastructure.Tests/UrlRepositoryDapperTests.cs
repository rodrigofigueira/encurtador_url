namespace Infrastructure.Tests;

public class UrlRepositoryDapperTests
{
    private readonly IUrlRepository _repository;

    public UrlRepositoryDapperTests()
    {
        const string dbFile = "test.db";
        if (File.Exists(dbFile))
            File.Delete(dbFile);

        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                services.AddPersistence(context.Configuration);
            })
            .Build();

        host.ApplyMigrations();

        var scope = host.Services.CreateScope();
        _repository = scope.ServiceProvider.GetRequiredService<IUrlRepository>();
    }

    [Fact]
    public async Task DeveInserirUrlComSucesso()
    {
        //arrange
        var entity = new UrlEntity(0, "abc123", "https://example.com");

        //act
        var result = await _repository.Post(entity);

        //assert
        Assert.NotEqual(0, result.Id);
        Assert.Equal("abc123", result.Alias);
    }
}
