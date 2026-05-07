using Moq;
using ScrummyWordCountApi.Core.Interfaces;
using ScrummyWordCountApi.Core.Services;
using Xunit;

namespace ScrummyWordCountApi.Tests.Core;

public class WordCountServiceTests
{
    private readonly WordCountService _sut = new(new Mock<ISearchRepository>().Object);

    public static TheoryData<string[], int> CountCases { get; } = new()
    {
        { new[] { "hello", "world", "hello", "Anders" }, 2 },
        { new[] { "Hello", "HELLO", "hello" }, 3 },
        { new[] { "Anders", "Jamie", "Momo" }, 0 },
        { Array.Empty<string>(), 0 },
    };

    [Theory]
    [MemberData(nameof(CountCases))]
    public async Task CountAndSaveAsync_ReturnsExpectedCount(string[] pageWords, int expected)
    {
        var result = await _sut.CountAndSaveAsync("https://example.com", "hello", pageWords);

        Assert.Equal(expected, result);
    }
}
