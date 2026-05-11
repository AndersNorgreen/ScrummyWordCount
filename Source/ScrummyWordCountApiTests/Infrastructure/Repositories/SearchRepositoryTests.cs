using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ScrummyWordCountApi.Infrastructure;
using ScrummyWordCountApi.Infrastructure.Repositories;
using Xunit;

namespace ScrummyWordCountApiTests.Infrastructure.Repositories;

public class SearchRepositoryTests
{
    [Fact]
    public async Task AddAsync_WhenGivenCorrectData_SavesAndReturnsResult()
    {
        // Arrange
        const string word = "test";
        const string url = "https://example.com";
        const int numberOfOccurrences = 2;
        
        // Act
        await using var connection = CreateConnection();
        await using var context = CreateContext(connection);
        var sut = GetSystemUnderTest(context);
        
        var result = await sut.AddAsync(word, url, numberOfOccurrences);
        
        var savedSearch = await context.Searches.FirstAsync();
        
        // Assert
        Assert.NotNull(result);
        
        Assert.Equal(word, savedSearch.Searchquery);
        Assert.Equal(url, savedSearch.Url);
        Assert.Equal(numberOfOccurrences, savedSearch.Numberofoccurrences);
    }

    private SearchRepository GetSystemUnderTest(ScrummyWordCountContext context)
    {
        return new SearchRepository(context);
    }

    private ScrummyWordCountContext CreateContext(SqliteConnection connection)
    {
        var options = new DbContextOptionsBuilder<ScrummyWordCountContext>()
            .UseSqlite(connection)
            .Options;
        
        var context = new ScrummyWordCountContext(options);
        context.Database.EnsureCreated();

        return context;
    }
    
    private SqliteConnection CreateConnection()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        
        return connection;
    }
}