namespace AssistantBot.Domain.Exceptions;

public class LocationException : Exception
{
    public LocationException(string message) : base(message)
    {
    }

    public static LocationException InvalidLongitude(string passed)
    {
        return new LocationException($"Ошибка: Передана неверная долгота. Передано: {passed}");
    }
    
    public static LocationException InvalidLatitude(string passed)
    {
        return new LocationException($"Ошибка: Передана неверная широта. Передано: {passed}");
    }
}