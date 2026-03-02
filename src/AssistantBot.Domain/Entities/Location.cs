using AssistantBot.Domain.Exceptions;

namespace AssistantBot.Domain.Entities;

public class Location
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Longitude { get; private set; } = null!;
    public string Latitude { get; private set; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public User User { get; private set; } = null!;
    
    private Location() {}

    public static Location Create(string longitude, string latitude, int userId)
    {
        if (!EnsureValidLongitude(longitude))
        {
            throw LocationException.InvalidLongitude(longitude);
        }
        
        if (!EnsureValidLatitude(latitude))
        {
            throw LocationException.InvalidLatitude(latitude);
        }
        
        return new Location
        {   
            Longitude = longitude,
            Latitude = latitude,
            UserId = userId
        };
    }

    private static bool EnsureValidLatitude(string latitute) =>
        !string.IsNullOrWhiteSpace(latitute) && double.TryParse(latitute, out _);

    private static bool EnsureValidLongitude(string longitude) =>
        !string.IsNullOrWhiteSpace(longitude) && double.TryParse(longitude, out _);
    
}