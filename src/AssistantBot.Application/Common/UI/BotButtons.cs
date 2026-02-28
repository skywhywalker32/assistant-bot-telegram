namespace AssistantBot.Application.Common.UI;

public static class BotButtons
{
    public static class MainMenu
    {
        public const string Account = "👤 Аккаунт";
        public const string AIChat = "🤖 ИИ чат";
        public const string Weather = "🌤 Погода";
        public const string Note = "📝 Заметки";
    }
    
    public static class AccountMenu
    {
        public const string Login = "Войти";
        public const string Create = "Создать";
        public const string Back = "⬅️ Назад";
    }
    
    public static class WeatherMenu
    {
        public const string Location = "Отправить свою локацию";
        public const string Back = "⬅️ Назад";
    }

    public static class NoteMenu
    {
        public const string PrintAll = "Вывести всё";
        public const string PrintById = "Вывести";
        public const string Add = "Добавить";
        public const string ChangeById = "Поменять";
        public const string DeleteById = "Удалить";
        public const string Back = "⬅️ Назад";
    }
}
