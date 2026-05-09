using Moq;
using ScrummyWordCountApi.Core.Interfaces;
using ScrummyWordCountApi.Core.Models;
using ScrummyWordCountApi.Core.Services;
using Xunit;

namespace ScrummyWordCountApi.Tests.Core;

public class WordCountServiceTests
{
    private readonly Mock<ISearchRepository> _repositoryMock;
    private readonly WordCountService _sut;

    public WordCountServiceTests()
    {
        _repositoryMock = new Mock<ISearchRepository>();
        _sut = new WordCountService(_repositoryMock.Object);
    }

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
        // Arrange
        _repositoryMock.Setup(x =>
            x.AddAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<int>()))
            .ReturnsAsync(new Search());
        
        // Act
        var result = await _sut.CountAndSaveAsync("https://example.com", "hello", pageWords);

        // Assert
        Assert.Equal(expected, result);
    }
}
