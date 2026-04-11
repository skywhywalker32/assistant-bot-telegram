namespace AssistantBot.Domain.Exceptions;

public class UserException : Exception
{
    public UserException(string message) : base(message)
    {
    }
    
    public static UserException NegativeOrZeroMessageId(int passed)
    {
        return new UserException($"Ошибка: Передано неверное значения для messageId. Должно быть >= 1" +
                                 $" Передано: {passed}");
    }
}