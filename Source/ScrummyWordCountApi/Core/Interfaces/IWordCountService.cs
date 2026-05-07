namespace ScrummyWordCountApi.Core.Interfaces;

public interface IWordCountService
{
    Task<int> CountAndSaveAsync(string url, string word, IEnumerable<string> pageWords);
}