namespace ScraperApp.Dtos;

public class LinksDto
{
    public required SelfLinkDto Self { get; set; }
    public PreviousEpisodeLinkDto? PreviousEpisode { get; set; } // Nullable based on JSON
}