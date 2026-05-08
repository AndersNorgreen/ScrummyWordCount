using ScrummyWordCountApi.Core.Interfaces;

namespace ScrummyWordCountApi.Core.Services;

public class WordCountService(ISearchRepository repository) : IWordCountService
{
    private static int CountWord(string word, IEnumerable<string> pageWords) =>
        pageWords.Count(pageWord => string.Equals(pageWord, word, StringComparison.OrdinalIgnoreCase));

    public async Task<int> CountAndSaveAsync(string url, string word, IEnumerable<string> pageWords)
    {
        var words = pageWords.ToArray();
        var count = CountWord(word, words);
        await repository.AddAsync(word, url, words, count);
        return count;
    }
}
