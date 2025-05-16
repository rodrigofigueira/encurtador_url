namespace Presentation.Tests.Endpoints;

public class UrlEndpointsPostTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task Post_Url_DeveRetornarCreated()
    {
        // Arrange
        var mockService = new Mock<IUrlService>();
        UrlDto urlDto = new(1, "https://exemplo.com", "https://original.com");

        mockService
            .Setup(s => s.Post(It.IsAny<UrlPostDto>()))
            .ReturnsAsync((UrlPostDto req) => urlDto);

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(mockService.Object);
            });
        }).CreateClient();

        var request = new UrlPostDto("https://exemplo.com", "https://original.com");

        // Act
        var response = await client.PostAsJsonAsync("/urls", request);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<UrlDto>();
        Assert.Equal(urlDto.Alias, body!.Alias);
        Assert.Equal(urlDto.Original, body.Original);
        Assert.Equal(urlDto.Id, body.Id);
    }
}
