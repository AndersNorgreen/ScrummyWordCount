using Microsoft.AspNetCore.Mvc;
using ScrummyWordCountApi.API.DTO;
using ScrummyWordCountApi.API.Services;
using ScrummyWordCountApi.Core.Interfaces;
using Xunit;
using Moq;

namespace ScrummyWordCountApiTests.API.Services;

public class WordCountEndpointServiceTests
{
    private readonly Mock<IWordCountService> _wordCountServiceMock;
    private readonly WordCountEndpointService _sut;

    private WordCountRequestDto _request = new WordCountRequestDto(
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<string[]>());

    public WordCountEndpointServiceTests()
    {
        _wordCountServiceMock = new Mock<IWordCountService>();
        _sut = new WordCountEndpointService(_wordCountServiceMock.Object);
    }

    [Fact]
    public async Task CountWordsAsync_WhenCalledWithCorrectDto_ReturnsCorrectResult()
    {
        // Arrange
        _wordCountServiceMock
            .Setup(x => x.CountAndSaveAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string[]>()))
            .ReturnsAsync(2);
        
        // Act
        var result = await _sut.CountWordsAsync(_request);
        var okResult = Assert.IsType<Microsoft.AspNetCore.Http.HttpResults.Ok<WordCountResponseDto>>(result);
        
        // Assert
        Assert.NotNull(okResult.Value);
        Assert.Equal(2, okResult.Value.NumberOfWordOccurences);
    }

    [Fact]
    public async Task CountWordsAsync_WhenExceptionIsThrown_ReturnsExceptionMessage()
    {
        // Arrange
        _wordCountServiceMock
            .Setup(x => x.CountAndSaveAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string[]>()))
            .ThrowsAsync(new Exception());
        
        // Act
        var result = await _sut.CountWordsAsync(_request);
        
        // Assert
        var badRequest = Assert.IsType<Microsoft.AspNetCore.Http.HttpResults.BadRequest<string>>(result);
        Assert.Equal("An error occured while counting words :(", badRequest.Value);
    }
}