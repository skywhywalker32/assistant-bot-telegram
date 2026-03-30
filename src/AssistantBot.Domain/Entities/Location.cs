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
        EnsureValidCoords(longitude, latitude);
        
        return new Location
        {   
            Longitude = longitude,
            Latitude = latitude,
            UserId = userId
        };
    }

    private static void EnsureValidCoords(string longitude, string latitude)
    {
        if (!EnsureValidLongitude(longitude))
        {
            throw LocationException.InvalidLongitude(longitude);
        }
        
        if (!EnsureValidLatitude(latitude))
        {
            throw LocationException.InvalidLatitude(latitude);
        }
    }

    private static bool EnsureValidLatitude(string latitute) =>
        !string.IsNullOrWhiteSpace(latitute) && double.TryParse(latitute, out _);

    private static bool EnsureValidLongitude(string longitude) =>
        !string.IsNullOrWhiteSpace(longitude) && double.TryParse(longitude, out _);
    
    public void UpdateCoords(string longitude, string latitude)
    {
        EnsureValidCoords(longitude, latitude);

        Longitude = longitude;
        Latitude = latitude;
    }
    
}