namespace ScrummyWordCountApi.API.DTO;

public record WordCountRequestDto(string Url, string SearchWord, IEnumerable<string> TextToSearch);