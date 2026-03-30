using AssistantBot.Domain.Exceptions;

namespace AssistantBot.Domain.Entities;

public class Note
{
    private static readonly int TitleCharsMax = 50;
    private static readonly int TextCharsMax = 1000;
    
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Text { get; private set; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public User User { get; private set; } = null!;
    
    private Note() { }

    public static Note Create(string title, string text, int userId)
    {
        EnsureValidNote(title, text);
        
        return new Note
        {
            Title = title,
            Text = text,
            UserId = userId
        };
    }
    
    private static void EnsureValidNote(string title, string text)
    {
        if (!EnsureValidTitle(title))
        {
            throw NoteException.InvalidTitleLength(TitleCharsMax, title.Length);
        }

        if (!EnsureValidText(text))
        {
            throw NoteException.InvalidTextLength(TextCharsMax, text.Length);
        }
    }

    private static bool EnsureValidTitle(string title) => 
        title.Length <= TitleCharsMax && !string.IsNullOrWhiteSpace(title);

    private static bool EnsureValidText(string text) =>
        text.Length <= TextCharsMax && !string.IsNullOrWhiteSpace(text);

    public void UpdateNote(string title, string text)
    {
        EnsureValidNote(title, text);

        Title = title;
        Text = text;
    }

}