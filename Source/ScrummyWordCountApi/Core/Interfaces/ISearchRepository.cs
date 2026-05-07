using ScrummyWordCountApi.Core.Models;

namespace ScrummyWordCountApi.Core.Interfaces;

public interface ISearchRepository
{
    Task AddAsync(string searchWord, string url, string[] searchedText, int wordCount);
}