using ToDoList.Shared;

namespace ToDoList.Client.Pages.ToDoListLocalComponents
{
    public interface IToDoListState
    {
        List<ToDoListSingleEntryDTO> Entries { get; }

        event Action? OnChange;

        void AddEntry(ToDoListSingleEntryDTO newEntry);
    }
}