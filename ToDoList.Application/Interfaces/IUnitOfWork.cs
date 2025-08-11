namespace ToDoList.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IToDoListListRepository ToDoListListRepository { get; }
        IToDoListSingleEntryRepository ToDoListSingleEntryRepository { get; }

        Task CompleteAsync();
    }
}