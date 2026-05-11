using System.Diagnostics;
using ScrummyWordCountApi.API.DTO;
using ScrummyWordCountApi.API.Services.Interfaces;
using ScrummyWordCountApi.Core.Interfaces;

namespace ScrummyWordCountApi.API.Services;

public class WordCountEndpointService(IWordCountService wordCountService) : IWordCountEndpointService
{
    public async Task<IResult> CountWordsAsync(WordCountRequestDto request)
    {
        try
        {
            var result = await wordCountService.CountAndSaveAsync(
                request.Url,
                request.SearchWord,
                request.TextToSearch);

            var response = new WordCountResponseDto(result);
            
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Results.BadRequest("An error occured while counting words :(");
        }
    }
}