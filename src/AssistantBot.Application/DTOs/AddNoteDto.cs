namespace AssistantBot.Application.DTOs;

public class AddNoteDto
{
    public string Title { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public long ChatId { get; init; }
}