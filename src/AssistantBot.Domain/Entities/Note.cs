namespace AssistantBot.Domain.Entities;

public class Note
{
    public int Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Text { get; private set; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public int UserId { get; private set; }
    public User User { get; private set; } = null!;
    
    
    private Note() { }
}