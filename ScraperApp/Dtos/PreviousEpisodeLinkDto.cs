namespace ScraperApp.Dtos;

public class PreviousEpisodeLinkDto
{
    public required string Href { get; set; }
    public string? Name { get; set; } // Nullable based on JSON
}