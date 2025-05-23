using System.Text;

namespace Infrastructure.Tests;

public class UrlRepositoryDapperTests
{
    private readonly IUrlRepository _repository;

    public UrlRepositoryDapperTests()
    {
        //const string dbFile = "test.db";

        string dbFile = $"test_{Guid.NewGuid():N}.db";
        var configJson = $@"{{
                              ""Database"": {{
                                ""Provider"": ""sqlite"",
                                ""ConnectionString"": ""Data Source={dbFile}""
                              }}
                            }}";

        var configStream = new MemoryStream(Encoding.UTF8.GetBytes(configJson));


        if (File.Exists(dbFile))
            File.Delete(dbFile);

        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, builder) =>
            {
                //builder.AddJsonFile("appsettings.json"); // menor precedência
                builder.AddJsonStream(configStream);     // maior precedência
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

    [Fact]
    public async Task DeveAtualizarUrlComSucesso()
    {
        //arrange
        UrlEntity entity = new(0, "abc123", "https://example.com");
        UrlEntity result = await _repository.Post(entity);
        UrlEntity entityUpdate = new(result.Id, "Alias Alterado", "Original Alterado");

        //act
        bool urlWasUpdated = await _repository.Put(entityUpdate);

        //assert
        Assert.True(urlWasUpdated);
    }

}
