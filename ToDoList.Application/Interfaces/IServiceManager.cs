namespace ToDoList.Application.Interfaces
{
    public interface IServiceManager
    {
        IToDoListService ToDoListService { get; }
        IToDoListSingleEntryService ToDoListSingleEntryService { get; }
    }
}