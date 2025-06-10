namespace Presentation.Endpoints;

public static class UrlEndpoints
{
    public static IEndpointRouteBuilder MapUrlEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/health", () => "Working...");

        app.MapPost("urls", async (UrlPostDto urlPostDto, IUrlService service) =>
        {
            var response = await service.Post(urlPostDto);
            return Results.Created($"/url/{response.Id}", response);
        });

        app.MapPut("urls", async (UrlPutDto urlPutDto, IUrlService service) =>
        {
            var response = await service.Put(urlPutDto);
            return Results.NoContent();
        });

        app.MapDelete("urls/{id}", async (int id, IUrlService service) =>
        {
            var response = await service.Delete(id);
            return Results.NoContent();
        });

        app.MapGet("urls/{id}", async (int id, IUrlService service) =>
        {
            var response = await service.Get(id);

            if (response is null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(response);

        });

        return app;
    }
}
