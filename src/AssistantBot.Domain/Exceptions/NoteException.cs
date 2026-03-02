namespace AssistantBot.Domain.Exceptions;

public class NoteException : Exception
{
    public NoteException(string message) : base(message)
    {
    }
    
    public static NoteException InvalidTitleLength(int limit, int passed)
    {
        return new NoteException($"Ошибка: Передано неверное количество символов для заголовка заметки (от 1 до {limit})." +
                                 $" Передано: {passed}");
    }
    
    public static NoteException InvalidTextLength(int limit, int passed)
    {
        return new NoteException($"Ошибка: Передано неверное количество символов для текста заметки (от 1 до {limit})." +
                                 $" Передано: {passed}");
    }
}