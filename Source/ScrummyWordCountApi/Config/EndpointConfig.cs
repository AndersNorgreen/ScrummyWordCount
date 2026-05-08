using ScrummyWordCountApi.API;

namespace ScrummyWordCountApi.Config;

public static class EndpointConfig
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddWordCountEndpoints();
    }
}