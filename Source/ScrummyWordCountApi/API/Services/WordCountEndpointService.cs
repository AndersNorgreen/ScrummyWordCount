using ScrummyWordCountApi.API.DTO;
using ScrummyWordCountApi.API.Services.Interfaces;
using ScrummyWordCountApi.Core.Interfaces;

namespace ScrummyWordCountApi.API.Services;

public class WordCountEndpointService(IWordCountService wordCountService) : IWordCountEndpointService
{
    public async Task<IResult> CountWords(WordCountRequestDto request)
    {
        try
        {
            var result = await wordCountService.CountWordAsync(
                request.Url,
                request.SearchWord,
                request.TextToSearch);

            var response = new WordCountResponseDto(result);
            
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}