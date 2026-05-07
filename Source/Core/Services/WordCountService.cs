using ScrummyWordCountApi.Core.Interfaces;

namespace ScrummyWordCountApi.Core.Services;

public class WordCountService : IWordCountService
{
    public Task<int> CountWordAsync(string url, string word, IEnumerable<string> pageWords)
    {
        var count = pageWords.Count(pageWord => string.Equals(pageWord, word, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(count);
    }
}
