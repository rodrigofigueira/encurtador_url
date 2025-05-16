namespace Presentation.Endpoints;

public static class UrlEndpoints
{
    public static IEndpointRouteBuilder MapUrlEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("urls", async (UrlPostDto urlPostDto, IUrlService service) =>
        {
            var response = await service.Post(urlPostDto);
            return Results.Created($"/url/{response.Id}", response);
        });

        return app;
    }
}
