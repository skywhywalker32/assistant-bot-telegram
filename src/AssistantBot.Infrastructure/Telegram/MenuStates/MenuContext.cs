namespace AssistantBot.Infrastructure.Telegram.MenuStates;

public class MenuContext
{
    private IMenuState _menuState;
    private readonly long _chatId;
    
    public MenuContext(IMenuState menuState, long chatId)
    {
        _menuState = menuState;
        _chatId = chatId;
    }

    public void SetState(IMenuState newMenuState) => _menuState = newMenuState;
    
    public void ProcessMessage() => _menuState.HandleMessage(this);
    
    public void ProcessCallback() => _menuState.HandleCallbackQuery(this);
}