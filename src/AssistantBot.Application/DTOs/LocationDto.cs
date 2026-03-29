namespace AssistantBot.Application.DTOs;

public class LocationDto
{
    public string Latitude { get; init; } = string.Empty;
    public string Longitude { get; init; } = string.Empty;
    public long ChatId { get; init; }
}