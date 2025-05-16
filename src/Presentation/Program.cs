var builder = WebApplication.CreateBuilder(args);

//todo: Define injections

var app = builder.Build();

app.MapGet("/", () => "Working...");

app.MapUrlEndpoints();
app.Run();

public partial class Program { }