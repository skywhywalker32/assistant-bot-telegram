namespace AssistantBot.Application.Common.UI;

public class BotCallbacks
{
    public static class MainMenu
    {
        public const string AIChatCallback = "ai_chat";
        public const string WeatherMenuCallback = "weather_menu";
        public const string NoteMenuCallback = "note_menu";
    }
    
    public static class WeatherMenu
    {
        public const string Location = "send_location";
        public const string Back = "back";
    }

    public static class NoteMenu
    {
        public const string PrintAll = "print_all_notes";
        public const string PrintById = "print_note_by_id";
        public const string Add = "add_note";
        public const string ChangeById = "update_note";
        public const string DeleteById = "delete_note";
        public const string Back = "back";
    }
    
    public static class AiChat
    {
        public const string Back = "back";
    }
}