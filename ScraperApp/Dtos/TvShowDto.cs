namespace ScraperApp.Dtos
{
    public class TvShowDto
    {
        public required int Id { get; set; }
        public required string Url { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Language { get; set; }
        public required List<string> Genres { get; set; }
        public required string Status { get; set; }
        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }
        public DateTime? Premiered { get; set; }
        public DateTime? Ended { get; set; }
        public string? OfficialSite { get; set; } // Optional based on JSON
        public required ScheduleDto Schedule { get; set; }
        public RatingDto? Rating { get; set; } // Rating can be nullable
        public required int Weight { get; set; }
        public required NetworkDto Network { get; set; }
        public object? WebChannel { get; set; } // Nullable based on JSON
        public object? DvdCountry { get; set; } // Nullable based on JSON
        public required ExternalsDto Externals { get; set; }
        public required ImageDto Image { get; set; }
        public required string Summary { get; set; }
        public required long Updated { get; set; }
        public required LinksDto _Links { get; set; }
    }
}
