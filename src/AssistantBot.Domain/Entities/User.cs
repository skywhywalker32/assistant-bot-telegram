using AssistantBot.Domain.Enums;
using AssistantBot.Domain.Exceptions;

namespace AssistantBot.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public long ChatId { get; private set; }
    public string? Username { get; private set; }

    public ActionState ActionState { get; private set; } = ActionState.None;
    public MenuState MenuState { get; private set; } = MenuState.MainMenu;

    public int MessageId { get; private set; } = -1;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public List<Note> Notes { get; private set; } = new();
    public Location? Location { get; private set; }
    
    private User() { }

    public static User Create(long chatId, string? username)
    {
        return new User
        {
            ChatId = chatId,
            Username = username ?? "User"
        };
    }

    public User UpdateUsername(string? newUsername)
    {
        if (newUsername != null && newUsername != Username)
        {
            Username = newUsername;
        }

        return this;
    }

    public void UpdateMenuState(MenuState newMenuState) =>
        MenuState = newMenuState;
    
    public void UpdateActionState(ActionState newActionState) => 
        ActionState = newActionState;

    public void UpdateMessageId(int msgId)
    {
        if (msgId <= 0)
        {
            throw UserException.NegativeOrZeroMessageId(msgId);
        }

        if (MessageId != msgId)
        {
            MessageId = msgId;
        }
    }
}
