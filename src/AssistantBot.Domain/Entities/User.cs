namespace AssistantBot.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public long ChatId { get; private set; }
    public string? Username { get; private set; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public List<Note> Notes { get; private set; } = new();


    private User() { }

    
}
