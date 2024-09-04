using ScraperApp.Models;

namespace ScraperApp;

/// <summary>
/// Interface defining operations required for a scrapper client
/// </summary>
public interface IScraperClient
{
    /// <summary>
    /// Method that retrieves tv show information for the API
    /// using as input the id of that show.
    /// </summary>
    /// <param name="showId">Show id used by external API</param>
    /// <returns></returns>
    Task<TvShow?> GetShow(int showId);
}