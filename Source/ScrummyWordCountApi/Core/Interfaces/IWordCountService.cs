namespace ScrummyWordCountApi.Core.Interfaces;

public interface IWordCountService
{
    Task<int> CountWordAsync(string url, string word, IEnumerable<string> pageWords);
    Task SaveSearchAsync(string url, string word, int count);
    Task<int> CountAndSaveAsync(string url, string word, IEnumerable<string> pageWords);
}