using ScrummyWordCountApi.Core.Interfaces;
using ScrummyWordCountApi.Core.Models;
using ScrummyWordCountApi.Infrastructure;

namespace ScrummyWordCountApi.Core.Services;

public class WordCountService(ScrummyWordCountContext context) : IWordCountService
{
    public Task<int> CountWordAsync(string url, string word, IEnumerable<string> pageWords)
    {
        var count = pageWords.Count(pageWord => string.Equals(pageWord, word, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(count);
    }

    public async Task SaveSearchAsync(string url, string word, int count)
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
        var count = await CountWordAsync(url, word, pageWords);
        await SaveSearchAsync(url, word, count);
        return count;
    }
}
