using Microsoft.EntityFrameworkCore;
using ScrummyWordCountApi.Core.Interfaces;
using ScrummyWordCountApi.Core.Models;
using ScrummyWordCountApi.Infrastructure;

public class SearchRepository : ISearchRepository
{
    private readonly ScrummyWordCountContext _context;

    public SearchRepository(ScrummyWordCountContext context)
    {
        _context = context;
    }

    public async Task AddAsync(string  searchWord, string url, string[] searchedText, int wordCount)
    {
        var search = new Search()
        {
            Url = url,
            Searchquery = searchWord,
            Numberofoccurrences = wordCount,
            Searchedat = DateTime.UtcNow
        };

        _context.Searches.Add(search);
        await _context.SaveChangesAsync();
    }
}