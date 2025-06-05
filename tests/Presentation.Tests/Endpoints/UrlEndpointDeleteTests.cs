namespace Presentation.Tests.Endpoints;

public class UrlEndpointDeleteTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task Delete_Url_DeveRetornarNoContent()
    {
        // Arrange
        var mockService = new Mock<IUrlService>();

        mockService
            .Setup(s => s.Delete(It.IsAny<int>()))
            .ReturnsAsync(() => true);

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(mockService.Object);
            });
        }).CreateClient();


        // Act
        var response = await client.DeleteAsync("/urls/1");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

}
