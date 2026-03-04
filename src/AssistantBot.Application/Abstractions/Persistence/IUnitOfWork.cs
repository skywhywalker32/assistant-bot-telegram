namespace AssistantBot.Application.Abstractions.Persistence;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}