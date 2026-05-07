using ScrummyWordCountApi.Core.Interfaces;
using ScrummyWordCountApi.Core.Models;
using ScrummyWordCountApi.Infrastructure;

namespace ScrummyWordCountApi.Core.Services;

public class WordCountService(ScrummyWordCountContext context) : IWordCountService
{
    private static int CountWord(string word, IEnumerable<string> pageWords) =>
        pageWords.Count(pageWord => string.Equals(pageWord, word, StringComparison.OrdinalIgnoreCase));

    private async Task SaveSearchAsync(string url, string word, int count)
    {
        context.Searches.Add(new Search
        {
            Url = url,
            Searchquery = word,
            Numberofoccurrences = count,
            Searchedat = DateTime.UtcNow
        });

        await context.SaveChangesAsync();
    }

    public async Task<int> CountAndSaveAsync(string url, string word, IEnumerable<string> pageWords)
    {
        var count = CountWord(word, pageWords);
        await SaveSearchAsync(url, word, count);
        return count;
    }
}
