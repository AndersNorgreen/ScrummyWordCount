using Scalar.AspNetCore;

namespace ScrummyWordCountApi.Config;

public static class OpenApiConfig
{
    public static void AddOpenApiServices(this IServiceCollection service)
    {
        service.AddOpenApi();
    }

    public static void UseOpenApi(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.Title = "Scrummy Word Count API";
            options.Theme = ScalarTheme.BluePlanet;
            options.HideClientButton = true;
        });
    }
}