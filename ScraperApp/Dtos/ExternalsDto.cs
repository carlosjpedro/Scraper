namespace ScraperApp.Dtos;

public class ExternalsDto
{
    public int? Tvrage { get; set; } // Nullable based on JSON
    public int? Thetvdb { get; set; } // Nullable based on JSON
    public string? Imdb { get; set; } // Nullable based on JSON
}