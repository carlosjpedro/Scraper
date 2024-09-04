namespace ScraperApp.Dtos;

public class NetworkDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required CountryDto Country { get; set; }
    public string? OfficialSite { get; set; } // Nullable based on JSON
}