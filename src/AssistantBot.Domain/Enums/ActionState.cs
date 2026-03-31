namespace AssistantBot.Domain.Enums;

public enum ActionState
{
    None,
    WaitingForNoteTitle,
    WaitingForNoteText,
    WaitingForLocation,
    WaitingForAiQuestion
}