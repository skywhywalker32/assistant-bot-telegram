namespace AssistantBot.Application.DTOs;

public class NoteDto
{
    public string Title { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public long ChatId { get; init; }
}