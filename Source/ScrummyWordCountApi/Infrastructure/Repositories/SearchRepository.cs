using System.Diagnostics;
using ScrummyWordCountApi.Core.Interfaces;
using ScrummyWordCountApi.Core.Models;

namespace ScrummyWordCountApi.Infrastructure.Repositories;

public class SearchRepository : ISearchRepository
{
    private readonly ScrummyWordCountContext _context;

    public SearchRepository(ScrummyWordCountContext context)
    {
        _context = context;
    }

    public async Task<Search> AddAsync(string searchWord, string url, int wordCount)
    {
        try
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

            return search;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }
    }
}