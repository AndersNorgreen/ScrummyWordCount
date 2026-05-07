using ScrummyWordCountApi.API.DTO;
using ScrummyWordCountApi.API.Services.Interfaces;

namespace ScrummyWordCountApi.API;

public static class WordCountEndpoint 
{
    public static void AddWordCountEndpoints(this WebApplication app)
    {
        app.MapPost(
            "/api/wordcount", 
            async (WordCountRequestDto request, IWordCountEndpointService wordCountEndpointService) => 
                await wordCountEndpointService.CountWords(request));
    }
}