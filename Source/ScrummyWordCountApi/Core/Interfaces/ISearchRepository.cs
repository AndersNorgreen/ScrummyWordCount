using ScrummyWordCountApi.Core.Models;

namespace ScrummyWordCountApi.Core.Interfaces;

public interface ISearchRepository
{
    Task<Search> AddAsync(string searchWord, string url, int wordCount);
}