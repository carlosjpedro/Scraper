using System.Net;
using System.Net.Http.Json;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ScraperApp.Dtos;
using ScraperApp.Models;

namespace ScraperApp;

public class TvMazeScraperClient : IScraperClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TvMazeScraperClient> _logger;
    private readonly IMapper _mapper;
    private const string ShowUri = "shows";

    public TvMazeScraperClient(HttpClient httpClient, ILogger<TvMazeScraperClient> logger, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(mapper);

        _httpClient = httpClient;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<TvShow?> GetShow(int showId)
    {
        _logger.LogInformation("Requesting show {showId} to the API", showId);
        try
        {
            var result = await _httpClient.GetFromJsonAsync<TvShowDto>($"{ShowUri}/{showId}");

            if (result == default)
            {
                _logger.LogWarning("API did not return data for showId {showId}", showId);
                return null;
            }

            _logger.LogInformation("API returned data for show {showId}, {result.Name}", showId, result.Name);
            return _mapper.Map<TvShow>(result);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            _logger.LogWarning("API did not return data for showId {showId}", showId);
            return null;
        }
    }
}