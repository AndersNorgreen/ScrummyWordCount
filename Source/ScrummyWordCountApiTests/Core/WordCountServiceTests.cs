using Microsoft.EntityFrameworkCore;
using ScrummyWordCountApi.Core.Services;
using ScrummyWordCountApi.Infrastructure;
using Xunit;

namespace ScrummyWordCountApi.Tests.Core;

public class WordCountServiceTests
{
    private static WordCountService CreateSut() =>
        new(new ScrummyWordCountContext(
            new DbContextOptionsBuilder<ScrummyWordCountContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options));

    private readonly WordCountService _sut = CreateSut();

    [Fact]
    public async Task CountWordAsync_ReturnsCorrectCount()
    {
        var words = new[] { "hello", "world", "hello", "Anders" };

        var result = await _sut.CountWordAsync("https://example.com", "hello", words);

        Assert.Equal(2, result);
    }

    [Fact]
    public async Task CountWordAsync_IsCaseInsensitive()
    {
        var words = new[] { "Hello", "HELLO", "hello" };

        var result = await _sut.CountWordAsync("https://example.com", "hello", words);

        Assert.Equal(3, result);
    }

    public static TheoryData<string[]> NoResultCases =>
    [
        ["Anders", "Jamie", "Momo"],
        []
    ];

    [Theory]
    [MemberData(nameof(NoResultCases))]
    public async Task CountWordAsync_ReturnsZero(string[] pageWords)
    {
        var result = await _sut.CountWordAsync("https://example.com", "hello", pageWords);

        Assert.Equal(0, result);
    }

    [Fact]
    public async Task SaveSearchAsync_PersistsRecordToDatabase()
    {
        var context = new ScrummyWordCountContext(
            new DbContextOptionsBuilder<ScrummyWordCountContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        var sut = new WordCountService(context);

        await sut.SaveSearchAsync("https://example.com", "hello", 5);

        var saved = Assert.Single(context.Searches);
        Assert.Equal("https://example.com", saved.Url);
        Assert.Equal("hello", saved.Searchquery);
        Assert.Equal(5, saved.Numberofoccurrences);
    }

    [Fact]
    public async Task CountAndSaveAsync_ReturnsCountAndPersistsRecord()
    {
        var context = new ScrummyWordCountContext(
            new DbContextOptionsBuilder<ScrummyWordCountContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
        var sut = new WordCountService(context);
        var words = new[] { "hello", "world", "hello", "Anders" };

        var result = await sut.CountAndSaveAsync("https://example.com", "hello", words);

        Assert.Equal(2, result);
        var saved = Assert.Single(context.Searches);
        Assert.Equal("https://example.com", saved.Url);
        Assert.Equal("hello", saved.Searchquery);
        Assert.Equal(2, saved.Numberofoccurrences);
    }
}