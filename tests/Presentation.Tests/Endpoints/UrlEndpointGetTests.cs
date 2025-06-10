namespace Presentation.Tests.Endpoints;

public class UrlEndpointGetTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task Get_Com_Id_Existente_Retorna_Url()
    {
        //arrange
        var mockService = new Mock<IUrlService>();

        mockService
            .Setup(s => s.Get(It.IsAny<int>()))
            .ReturnsAsync(() => new UrlDto(1, "", ""));

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(mockService.Object);
            });
        }).CreateClient();

        //act
        var response = await client.GetAsync("/urls/1");

        //assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Get_Com_Id_Inexistente_Nao_Retorna_Url()
    {
        //arrange
        var mockService = new Mock<IUrlService>();

        mockService
            .Setup(s => s.Get(It.IsAny<int>()))
            .ReturnsAsync(() => null!);

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(mockService.Object);
            });
        }).CreateClient();

        //act
        var response = await client.GetAsync("/urls/1");

        //assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

}
