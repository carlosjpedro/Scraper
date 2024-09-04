using System.Net;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RichardSzalay.MockHttp;
using ScraperApp;
using ScraperApp.Dtos;
using ScraperApp.Models;
using Bogus;

namespace ScrapperApp.Tests
{
    public class TvMazeScraperClientTests
    {
        private readonly MockHttpMessageHandler _mockHttp;
        private readonly HttpClient _httpClient;
        private readonly TvMazeScraperClient _tvMazeScraperClient;

        public TvMazeScraperClientTests()
        {
            _mockHttp = new MockHttpMessageHandler();
            _httpClient = _mockHttp.ToHttpClient();
            _httpClient.BaseAddress = new Uri("https://test.url/");

            var logger = NullLogger<TvMazeScraperClient>.Instance;
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new TvShowMappingProfile())));

            _tvMazeScraperClient = new TvMazeScraperClient(_httpClient, logger, mapper);
        }

        [Fact]
        public async Task GetShow_ValidShowId_ReturnsMappedTvShow()
        {
            // Arrange
            const int showId = 1;
            const string showName = "Test Show";
            var tvShowDto = new Faker<TvShowDto>()
                .RuleFor(show => show.Id, showId)
                .RuleFor(show => show.Name, showName)
                .Generate();
            

            // Set up mock response for the expected GET request
            _mockHttp.When($"{_httpClient.BaseAddress}shows/{showId}")
                .Respond("application/json", JsonSerializer.Serialize(tvShowDto));
            
            // Act
            var result = await _tvMazeScraperClient.GetShow(showId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(showName, result.Name);
            Assert.Equal(showId, result.ApiId);
        }

        [Fact]
        public async Task GetShow_ApiReturnsNotFound_ReturnsNull()
        {
            // Arrange
            const int showId = 1;
            
            _mockHttp.When($"{_httpClient.BaseAddress}shows/{showId}")
                .Respond(HttpStatusCode.NotFound);

            // Act
            var result = await _tvMazeScraperClient.GetShow(showId);

            // Assert
            Assert.Null(result);
        }
    }

}