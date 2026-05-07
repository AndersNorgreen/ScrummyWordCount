namespace ScrummyWordCountApi.Core.Interfaces;

public interface IWordCountService
{
    Task<int> CountWordAsync(string url, string word, IEnumerable<string> pageWords);
}
