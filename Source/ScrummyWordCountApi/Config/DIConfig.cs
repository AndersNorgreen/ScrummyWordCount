using ScrummyWordCountApi.API.Services;
using ScrummyWordCountApi.API.Services.Interfaces;
using ScrummyWordCountApi.Core.Interfaces;
using ScrummyWordCountApi.Core.Services;

namespace ScrummyWordCountApi.Config;

public static class DIConfig
{
    public static void AddDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISearchRepository, SearchRepository>();
        builder.Services.AddScoped<IWordCountService, WordCountService>();
        builder.Services.AddScoped<IWordCountEndpointService, WordCountEndpointService>();
    }
}