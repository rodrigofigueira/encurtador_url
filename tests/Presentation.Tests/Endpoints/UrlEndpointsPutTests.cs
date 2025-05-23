namespace Presentation.Tests.Endpoints;

public class UrlEndpointsPutTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task Put_Url_DeveRetornarNoContent()
    {
        // Arrange
        var mockService = new Mock<IUrlService>();

        mockService
            .Setup(s => s.Put(It.IsAny<UrlPutDto>()))
            .ReturnsAsync(() => true);

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(mockService.Object);
            });
        }).CreateClient();

        var request = new UrlPutDto(1, "https://exemplo.com", "https://original.com");

        // Act
        var response = await client.PutAsJsonAsync("/urls", request);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}
