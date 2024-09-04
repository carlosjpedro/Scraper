namespace ScraperApp.Dtos;

public class ScheduleDto
{
    public required string Time { get; set; }
    public required List<string> Days { get; set; }
}