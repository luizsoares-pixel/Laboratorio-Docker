var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var environment =
    Environment.GetEnvironmentVariable("APP_ENVIRONMENT")
    ?? "development";

var version =
    Environment.GetEnvironmentVariable("APP_VERSION")
    ?? "local";

app.MapGet("/", () => new
{
    application = "DevOps Web API",
    version,
    environment
});

app.MapGet("/version", () => new
{
    version,
    environment,
    message = "Nova funcionalidade da versão 1.1"
});

// Endpoint de Health Check corrigido para responder com sucesso (200 OK)
app.MapGet("/health", () =>
    Results.Ok(new
    {
        status = "Healthy",
        environment,
        version
    })
);

app.Run();