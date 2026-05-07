using ScrummyWordCountApi.API.DTO;

namespace ScrummyWordCountApi.API.Services.Interfaces;

public interface IWordCountEndpointService
{
    Task<IResult> CountWordsAsync(WordCountRequestDto request);
}